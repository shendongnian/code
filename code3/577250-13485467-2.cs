       string[] splitStr = sentence.Split(' ');
       if (splitStr.Length > 2)
       {
           int thirdLargestWordLength = splitStr.OrderByDescending(x => x.Length)
                                                 .Skip(2).Take(1).FirstOrDefault().Length;
            if (splitStr[0].Length != thirdLargestWordLength && 
             splitStr[1].Length != thirdLargestWordLength)
             {
                string[] theThirdLargestWords = splitStr.Where(x => x.Length == thirdLargestWordLength)
                                                                      .ToArray();
            
                 if (theThirdLargestWords.Length == 1)
                 {
                    label9.Text = "The third longest word is " + theThirdLargestWords[0];
                 }
                 else
                 {
                    string words = "";
                    for (int i = 0; i < theThirdLargestWords.Length; i++)
                    {
                       if (i == 0)
                       {
                         words = theThirdLargestWords[i];
                    }
                   //else if ((i + 1) == theThirdLargestWords.Length)
                   //{
                   //   words += " and " + theThirdLargestWords[i];
                   //}
                    else
                    {
                        words += ", " + theThirdLargestWords[i];
                    }
                 }
                 label9.Text = "The third longest words are " + words;
            }
          }
       }
