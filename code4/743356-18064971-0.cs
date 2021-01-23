    internal string i()
            {
                this.Parse();
                string str = "<?xml version=\"1.0\" ?>";
                string str1 = lzbasetype.PPAddLinebreak(str);
                object[] dbVendorStr = new object[] { lzbasetype.DbVendorStr[(int)this.i] };
                str = string.Concat(str1, SysUtils.Format("<sqlscript dbvendor=\"%s\">", dbVendorStr));
                if (this.ErrorCount <= 0)
                {
                    int num = this.SqlStatements.Count() - 1;
                    int num1 = 0;
                    if (num >= num1)
                    {
                        num++;
                        do
                        {
                            str = string.Concat(lzbasetype.PPAddLinebreak(str), this.SqlStatements[num1].AsXmlText);
                            num1++;
                        }
                        while (num1 != num);
                    }
                    str = string.Concat(lzbasetype.PPAddLinebreak(str), "</sqlscript>");
                }
                else
                {
                    str = string.Concat(lzbasetype.PPAddLinebreak(str), "<SyntaxError>");
                    str = string.Concat(lzbasetype.PPAddLinebreak(str), this.ErrorMessages);
                    str = string.Concat(lzbasetype.PPAddLinebreak(str), "</SyntaxError>");
                    str = string.Concat(lzbasetype.PPAddLinebreak(str), "</sqlscript>");
                }
                return str;
            }
