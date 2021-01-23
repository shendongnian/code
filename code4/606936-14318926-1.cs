            string original_string = "Hello     ,     how    are   you    ?";
            var poss = GetWhiteSpacePos(original_string).ToList();
            int startPos;
            int endPos;
            StringBuilder builder = new StringBuilder(original_string);
            for (int i = poss.Count -1; i > 1; i--)
            {
                endPos = poss[i];
                while ((poss[i] == poss[i - 1] + 1) && i  > 1)
                {
                    i--;
                }
                startPos = poss[i];
                if (endPos - startPos > 1)
                {
                    builder.Remove(startPos, endPos - startPos);
                }
                
            }
            string new_string = builder.ToString();
