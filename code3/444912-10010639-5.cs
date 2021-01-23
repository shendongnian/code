        bool IsInputValid(string input)
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
                if (IsBracket(character)) // redundant?
                {
                    if (character == '(') // then what?
                    if (character == ')') // then what?
                }
                if (bracketsCounter < what?)
                {
                    what?
                }
            }
            return bracketsCounter == what?;
        }
