     private int[] ConvertDecimalCharArrayToBinaryCharArray(int[] decimalValues)
        {
            List<int> result = new List<int>();
            bool end = false;
            while (end == false)
            {
                result.Add(decimalValues[decimalValues.Length - 1] % 2);
                int previous = 0;
                bool allzeros = true;
                for (int i = 0; i < decimalValues.Length; i++)
                {
                    var x = decimalValues[i];
                    if (x != 0)
                    {
                        allzeros = false;
                    }
                    if (allzeros && i == decimalValues.Length - 1)
                    {
                        end = true;
                    }
                    var a = (x + previous) / 2;
                    if ((x + previous) % 2== 1)
                    {
                        previous = 10;
                    }
                    else
                    {
                        previous = 0;
                    }
                    decimalValues[i] = a;
                }
            }
            result.RemoveAt(result.Count - 1);
            result.Reverse();
            return result.ToArray();
        }
