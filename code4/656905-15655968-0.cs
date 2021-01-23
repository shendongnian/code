            string result = string.Empty;
            for (int i = 0; i < text.ToArray().Length; i++)
            {
                char c = text.ToArray()[i];
                if (i%16 != 0)
                    result += c;
                else
                    result += "," + c;
            }
