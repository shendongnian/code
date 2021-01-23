		string english = "wall";
           string pigLatin = "";
           string firstLetter;
           string restOfWord;
           string vowels = "AEIOUaeiou";
           int letterPos;
          foreach (string word in english.Split())
          {
              firstLetter = word.Substring(0, 1);
              restOfWord = word.Substring(1, word.Length - 1);
              letterPos = vowels.IndexOf(firstLetter);
              if (letterPos == -1)
              {
                  //it's a consonant
                  pigLatin = restOfWord + firstLetter + "ay";
              }
              else
              {
                  //it's a vowel
                  pigLatin = word + "way";
              }
            }        
    //pigLatin should be "allway", I think.  
