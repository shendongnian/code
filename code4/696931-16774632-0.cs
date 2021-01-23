            input = input.Replace("MaxUpperLimit", MaxUpperLimit.ToString());
            bool isLimitExceeded = false;
            int result = 0;
            foreach (var komma in input.Split(",".ToCharArray()))
            {
                if (komma.Contains("-"))
                {
                    foreach (var minus in komma.Split("-".ToCharArray()))
                    {
                        if (!Int32.TryParse(minus, out result) || result > MaxUpperLimit)
                        {
                            isLimitExceeded = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (!Int32.TryParse(komma, out result) || result > MaxUpperLimit || isLimitExceeded)
                    {
                        isLimitExceeded = true;
                        break;
                    }
                }
            }
