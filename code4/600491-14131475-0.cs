        for (int index = 0; index < Lines.Length; index++)
        {
            string Line = Lines[index];
            int Pos = 0;
            string Word;
            while ((Word = ParseWord(ref Line, ref Pos)) != null)
            {
                // Do something with Word
            }
        }
