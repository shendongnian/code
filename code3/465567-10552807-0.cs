        private int FindNextPaladindrone(int value)
        {
            int result = 0;
            bool found = false;
            while (!found)
            {
                value++;
                found = IsPalindrone(value);
                if (found)
                    result = value;
            }
            return result;
        }
        private bool IsPalindrone(int number)
        {
            string numberString = number.ToString();
            int backIndex;
            bool same = true;
            for (int i = 0; i < numberString.Length; i++)
            {
                backIndex = numberString.Length - (i + 1);
                if (i == backIndex || backIndex < i)
                    break;
                else
                {
                    if (numberString[i] != numberString[backIndex])
                    {
                        same = false;
                        break;
                    }
                }
            
            return same;
        }
