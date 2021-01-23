		public static string ProcessEnglishHebrewSentence(string sentence)
		{
			var ret = new List<string>();
			string[] words = sentence.Split(' ');
			
			var curHebrewList = new List<string>();
			var curEnglishList = new List<string>();
			bool curLangIsHebrew=false;
			
			foreach(var w in words)
			{
				if(IsHebrew(w) && curLangIsHebrew) // we have a word in Hebrew and the last word was in Hebrew too
				{
					curHebrewList.Add(w);
				}
				else if(IsHebrew(w) && !curLangIsHebrew) // we have a word in Hebrew and the last word was in English
				{
					if(curEnglishList.Any()) 			{
						curEnglishList.Reverse();
						ret.AddRange(curEnglishList);
					} // reverse current list of English words and add to List
					curEnglishList = new List<string>(); // create a new empty list for the next series of English words
					curHebrewList.Add(w);
					curLangIsHebrew=true; // set current language to Hebrew
				}
				else if(!IsHebrew(w) && !curLangIsHebrew) // we have a word in English and the last word was in English
				{
					curEnglishList.Add(new String(w.Reverse().ToArray())); // reverse and add it to the current series of English words
				}
				else if(!IsHebrew(w) && curLangIsHebrew) // we have a word in English and the last word was in Hebrew
				{
					if(curHebrewList.Any()) ret.AddRange(curHebrewList); // add current list of Hebrew words to List of Lists
					curHebrewList = new List<string>(); // create a new empty list for the next series of Hebrew words
					curEnglishList.Add(new string(w.Reverse().ToArray()));
					curLangIsHebrew=false; // set current language to English
				}
				else
				{
					throw new Exception("there should be no other case...");
				}
			}
			if(curHebrewList.Any()) ret.AddRange(curHebrewList);
			if(curEnglishList.Any())
			{
				curEnglishList.Reverse();
				ret.AddRange(curEnglishList);
			}
			return ret.Aggregate((a,b) => a + " " + b);
		}
