      public void Read(string text) // Lets say text has length 250 (>100)
        {
            DeleteFile();
            if (text.Length > 100)
                text = text.Substring(0, 100);
            ReadText(text);
            PlaySound();
        }
