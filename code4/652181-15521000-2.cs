            static void Main(string[] args)
            {
                string a = "8fcc44";            
                int itemNumber = 0;
                int[] iArray = new int[3];
                for (int i = 0; i < a.Length - 1; i += 2)
                {
                    iArray[itemNumber] = (int.Parse(a.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
                    itemNumber++;
                }
            }
