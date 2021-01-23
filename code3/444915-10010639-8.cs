        bool IsNumeric(char character)
        {
            return "0123456789".Contains(character);
            // or return Char.IsNumber(character);
        }
        bool IsLetter(char character)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXWZabcdefghigjklmnopqrstuvwxyz".Contains(character);
        }
        bool IsRecognized(char character)
        {
            return IsBracket(character) | IsNumeric(character) | IsLetter(character);
        }
        public bool IsValidInput(string input)
        {
            if (String.IsNullOrEmpty(input) || IsBracket(input[0]))
            {
                return false;
            }
            var bracketsCounter = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i];
                if (!IsRecognized(character))
                {
                    return false;
                }
                if (IsBracket(character))
                {
                    if (character == '(')
                        bracketsCounter++;
                    if (character == ')')
                        bracketsCounter--;
                }
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (bracketsCounter < 0) // NOT "> 0", and HERE - INSIDE the for loop
                {
                    return false;
                }
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            return bracketsCounter==0;
        }
    }
    }
