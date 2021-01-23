      public void Read(string text) // Lets say text has length 250 (>100)
        {
            //DeleteFile();
            
            int startIndex = 0;
            string textToPlay = text;
            string remainingText = text;
            while (remainingText.Length > 100)
            {
                textToPlay = text.Substring(startIndex, 100);
                
                startIndex = startIndex + 101;
                remainingText = text.Substring(startIndex);
                ReadText(textToPlay);
            }
            ReadText(remainingText);
            PlaySound();
        }
