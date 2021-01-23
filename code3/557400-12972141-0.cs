        public static int calculate(int i)
            {
                string a = Convert.ToString(i, 2);
                int[] array = new int[a.Length];
                int number = 0;
                for (int n = 0; n < a.Length; n++)
                {
                    array[n] = Convert.ToInt32(a[n].ToString()); // build an array of intigers representing the bits valies such as 0011100
                }
    
                for (int n = 0; n < array.Length; n++)
                {
                    if (array[n] == 0)
                    {
                        number = number + 1;
                    }
                }
                return number;
            }
