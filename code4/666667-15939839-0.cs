        public char[] drawProgress(char letterGuess, char[] wordToGuess, char[] displayString)
        {
            for (int a = 0; a < wordToGuess.Length; a++)
            {
                if (wordToGuess[a] == letterGuess)
                {
                    displayString[a] = letterGuess;
                }
            }
            return displayString;
        }
