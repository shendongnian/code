	public class NumToWords
	{
		public NumToWords()
		{}
		string[] OneToNineteen = 
			{ "zero",   
			  "one",    "two",    "three",    "four",     "five",    "six",     "seven",     "eight",    "nine",   "ten",   
			  "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
		// empty string for zero-place-holder for tens grouping
		string[] Tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
		// leave blank for "hundreds" because you would NOT do 123 as One hundred twenty-three hundred.
		string[] Block3Section = { "", "thousand", "million", "billion" };
		public string ToEnglish(int num)
		{
			int Block3Seq = 0;
			int curSegment;
			int tmp;
			string FinalWords = "";
			string curWord = "";
			while (num > 0)
			{
				curSegment = num % 1000;	// get only 3 digits worth (right) of the number
				num = (num - curSegment) / 1000;  // subtract this portion from the value
				if (curSegment > 0)
				{
					// always add the closing word as we HAVE something to build out
					curWord = "";
					// how many "hundreds" of the current segment
					tmp = (int)curSegment / 100;
					if (tmp > 0)
						curWord += " " + OneToNineteen[tmp] + " hundred";
					// what is remainder of this 100 based segment
					tmp = curSegment % 100;
					if (tmp < 20)
						curWord += " " + OneToNineteen[tmp];
					else
					{
						curWord += " " + Tens[(int)tmp / 10]
									+ '-' + OneToNineteen[tmp % 10];
					}
					// always add the closing word as we HAVE something to build out
					curWord += " " + Block3Section[Block3Seq];
					// add the section above to the overall words
					FinalWords = curWord + FinalWords;
				}
	
				// to allow the next closing word for segment such as thousand, million, billion, etc
				Block3Seq++;
			}
			return FinalWords;
		}
	}
