	public class NumToWords
	{
		public NumToWords()
		{}
		string[] OneToNineteen = 
			{ "Zero",   
			  "One",    "Two",    "Three",    "Four",     "Five",    "Six",     "Seven",     "Eight",    "Nine",   "Ten",   
			  "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
		// empty string for zero-place-holder for tens grouping
		string[] Tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
		// leave blank for "hundreds"
		string[] Block3Section = { "", "thousand", "million" };
		public string GetTheWords( double num )
		{ 
			// in case of like check-writing, what are the CENTs portion
			double remain = num - (int)num;
			// Now, the whole number
			int whole = (int)num;
			int segment;
			string curSection;
			string FinalWords = "";
			// convert to a string
			string NumAsString = whole.ToString().Trim();
			int tmp;
			
			while( NumAsString.Length > 0 )
			{
				// how many characters in the string based on multiple of 3 positions
				// Ex: 9 =  1,    99 = 2, 999 = 3,   
				// 9999 = 1 in the thousands group,   9999 = 2 in the thousands group
				// 9999999 = 1 in the millions group
				// Ex: 12,345 = 2 digits in the thousands group
				segment = ( NumAsString.Length % 3 );
				// if exact 3 digits, the MODULUS = 0, so set to 3
				if (segment == 0)
					segment = 3;
				// analyze this segment, getting
				curSection = NumAsString.Substring(0, segment ).PadLeft( 3, '0' );
				// Now, for the current section.  If the first position is NOT a zero, then we
				// want that number + " hundred".  Ex: 123 = "One hundred"
				tmp = int.Parse( curSection.Substring(0,1));
				if( tmp > 0 )
					FinalWords += OneToNineteen[tmp] + " hundred ";
				// Now, get the second position... is it less than 2 (ie: 1-19)
				tmp = int.Parse( curSection.Substring(1,1));
				if( tmp < 2 )
				{
					// Yup, from 0 to 19 we need value of BOTH 2nd and 3rd position
					tmp = int.Parse( curSection.Substring(1,2));
					FinalWords += OneToNineteen[tmp] + " ";
				}
				else
				{
					// Nope, its a minimum of 20... so we need each part on its own...
					// ex: 25 = "twenty" and "five"
					FinalWords += Tens[ tmp ] + "-";
					// Now, get the ones position
					tmp = int.Parse( curSection.Substring(2,1));
					FinalWords += OneToNineteen[tmp] + " ";
				}
				// for the section (ie: thousands / millions ), tack on AFTER the group
				// subtract 1 to remain in proper wording group.  Ex: 12,345,678 as as string
				// is "12345678", total 8 chars and within the millions.  8 / 3 = 2nd "Block3Section"
				// is "million".  It would still be 2 if we have (8-1) / 3
				// After the "12" gets processed for millions, we the process the
				// "345" for the thousands section, but since we are at exactly multiple of 3 length
				// string, we need to subtract 1 to drop down to the THOUSANDs group (6-1)/3 = 1st "Block3Section"
				// and returning "thousand".  Finally at "678" the hundreds block (3-1)/3 = 0 in "Block3Section" which is blank
				FinalWords += Block3Section[(int)((NumAsString.Length -1)/ 3)] + " ";
				
				// strip off the portion we just processed
				NumAsString = NumAsString.Substring( segment );
			}
			// and if you wanted to tack-on the remaining balance of 2 digits such as money (cents) representation
			if (remain > 0.00)
			{
				FinalWords += "and ";
				// similar, but multiply by 100 to get two positions
				tmp = (int)(remain * 100);
				if (tmp < 20)
					FinalWords += OneToNineteen[tmp] + " ";
				else
				{
					// we need the 20, 30, 40, etc... portion
					FinalWords += Tens[(int)(tmp/10)] + "-";
					// Now, just the ones position
					tmp = tmp - ((int)(tmp / 10)) * 10;
					FinalWords += OneToNineteen[tmp] + " ";
				}
                                
                                FinalWords += "cents";
			}
			return FinalWords;
		}
	}
