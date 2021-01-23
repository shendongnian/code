    // System.Number
    private unsafe static bool ParseNumber(ref char* str, NumberStyles options, ref Number.NumberBuffer number, NumberFormatInfo numfmt, bool parseDecimal)
    {
    	number.scale = 0;
    	number.sign = false;
    	string text = null;
    	string text2 = null;
    	string str2 = null;
    	string str3 = null;
    	bool flag = false;
    	string str4;
    	string str5;
    	if ((options & NumberStyles.AllowCurrencySymbol) != NumberStyles.None)
    	{
    		text = numfmt.CurrencySymbol;
    		if (numfmt.ansiCurrencySymbol != null)
    		{
    			text2 = numfmt.ansiCurrencySymbol;
    		}
    		str2 = numfmt.NumberDecimalSeparator;
    		str3 = numfmt.NumberGroupSeparator;
    		str4 = numfmt.CurrencyDecimalSeparator;
    		str5 = numfmt.CurrencyGroupSeparator;
    		flag = true;
    	}
    	else
    	{
    		str4 = numfmt.NumberDecimalSeparator;
    		str5 = numfmt.NumberGroupSeparator;
    	}
    	int num = 0;
    	char* ptr = str;
    	char c = *ptr;
    	while (true)
    	{
    		if (!Number.IsWhite(c) || (options & NumberStyles.AllowLeadingWhite) == NumberStyles.None || ((num & 1) != 0 && ((num & 1) == 0 || ((num & 32) == 0 && numfmt.numberNegativePattern != 2))))
    		{
    			bool flag2;
    			char* ptr2;
    			if ((flag2 = ((options & NumberStyles.AllowLeadingSign) != NumberStyles.None && (num & 1) == 0)) && (ptr2 = Number.MatchChars(ptr, numfmt.positiveSign)) != null)
    			{
    				num |= 1;
    				ptr = ptr2 - (IntPtr)2 / 2;
    			}
    			else
    			{
    				if (flag2 && (ptr2 = Number.MatchChars(ptr, numfmt.negativeSign)) != null)
    				{
    					num |= 1;
    					number.sign = true;
    					ptr = ptr2 - (IntPtr)2 / 2;
    				}
    				else
    				{
    					if (c == '(' && (options & NumberStyles.AllowParentheses) != NumberStyles.None && (num & 1) == 0)
    					{
    						num |= 3;
    						number.sign = true;
    					}
    					else
    					{
    						if ((text == null || (ptr2 = Number.MatchChars(ptr, text)) == null) && (text2 == null || (ptr2 = Number.MatchChars(ptr, text2)) == null))
    						{
    							break;
    						}
    						num |= 32;
    						text = null;
    						text2 = null;
    						ptr = ptr2 - (IntPtr)2 / 2;
    					}
    				}
    			}
    		}
    		c = *(ptr += (IntPtr)2 / 2);
    	}
    	int num2 = 0;
    	int num3 = 0;
    	while (true)
    	{
    		if ((c >= '0' && c <= '9') || ((options & NumberStyles.AllowHexSpecifier) != NumberStyles.None && ((c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))))
    		{
    			num |= 4;
    			if (c != '0' || (num & 8) != 0)
    			{
    				if (num2 < 50)
    				{
    					number.digits[(IntPtr)(num2++)] = c;
    					if (c != '0' || parseDecimal)
    					{
    						num3 = num2;
    					}
    				}
    				if ((num & 16) == 0)
    				{
    					number.scale++;
    				}
    				num |= 8;
    			}
    			else
    			{
    				if ((num & 16) != 0)
    				{
    					number.scale--;
    				}
    			}
    		}
    		else
    		{
    			char* ptr2;
    			if ((options & NumberStyles.AllowDecimalPoint) != NumberStyles.None && (num & 16) == 0 && ((ptr2 = Number.MatchChars(ptr, str4)) != null || (flag && (num & 32) == 0 && (ptr2 = Number.MatchChars(ptr, str2)) != null)))
    			{
    				num |= 16;
    				ptr = ptr2 - (IntPtr)2 / 2;
    			}
    			else
    			{
    				if ((options & NumberStyles.AllowThousands) == NumberStyles.None || (num & 4) == 0 || (num & 16) != 0 || ((ptr2 = Number.MatchChars(ptr, str5)) == null && (!flag || (num & 32) != 0 || (ptr2 = Number.MatchChars(ptr, str3)) == null)))
    				{
    					break;
    				}
    				ptr = ptr2 - (IntPtr)2 / 2;
    			}
    		}
    		c = *(ptr += (IntPtr)2 / 2);
    	}
    	bool flag3 = false;
    	number.precision = num3;
    	number.digits[(IntPtr)num3] = '\0';
    	if ((num & 4) != 0)
    	{
    		if ((c == 'E' || c == 'e') && (options & NumberStyles.AllowExponent) != NumberStyles.None)
    		{
    			char* ptr3 = ptr;
    			c = *(ptr += (IntPtr)2 / 2);
    			char* ptr2;
    			if ((ptr2 = Number.MatchChars(ptr, numfmt.positiveSign)) != null)
    			{
    				c = *(ptr = ptr2);
    			}
    			else
    			{
    				if ((ptr2 = Number.MatchChars(ptr, numfmt.negativeSign)) != null)
    				{
    					c = *(ptr = ptr2);
    					flag3 = true;
    				}
    			}
    			if (c >= '0' && c <= '9')
    			{
    				int num4 = 0;
    				do
    				{
    					num4 = num4 * 10 + (int)(c - '0');
    					c = *(ptr += (IntPtr)2 / 2);
    					if (num4 > 1000)
    					{
    						num4 = 9999;
    						while (c >= '0' && c <= '9')
    						{
    							c = *(ptr += (IntPtr)2 / 2);
    						}
    					}
    				}
    				while (c >= '0' && c <= '9');
    				if (flag3)
    				{
    					num4 = -num4;
    				}
    				number.scale += num4;
    			}
    			else
    			{
    				ptr = ptr3;
    				c = *ptr;
    			}
    		}
    		while (true)
    		{
    			if (!Number.IsWhite(c) || (options & NumberStyles.AllowTrailingWhite) == NumberStyles.None)
    			{
    				bool flag2;
    				char* ptr2;
    				if ((flag2 = ((options & NumberStyles.AllowTrailingSign) != NumberStyles.None && (num & 1) == 0)) && (ptr2 = Number.MatchChars(ptr, numfmt.positiveSign)) != null)
    				{
    					num |= 1;
    					ptr = ptr2 - (IntPtr)2 / 2;
    				}
    				else
    				{
    					if (flag2 && (ptr2 = Number.MatchChars(ptr, numfmt.negativeSign)) != null)
    					{
    						num |= 1;
    						number.sign = true;
    						ptr = ptr2 - (IntPtr)2 / 2;
    					}
    					else
    					{
    						if (c == ')' && (num & 2) != 0)
    						{
    							num &= -3;
    						}
    						else
    						{
    							if ((text == null || (ptr2 = Number.MatchChars(ptr, text)) == null) && (text2 == null || (ptr2 = Number.MatchChars(ptr, text2)) == null))
    							{
    								break;
    							}
    							text = null;
    							text2 = null;
    							ptr = ptr2 - (IntPtr)2 / 2;
    						}
    					}
    				}
    			}
    			c = *(ptr += (IntPtr)2 / 2);
    		}
    		if ((num & 2) == 0)
    		{
    			if ((num & 8) == 0)
    			{
    				if (!parseDecimal)
    				{
    					number.scale = 0;
    				}
    				if ((num & 16) == 0)
    				{
    					number.sign = false;
    				}
    			}
    			str = ptr;
    			return true;
    		}
    	}
    	str = ptr;
    	return false;
    }
