            double doubleValue = 13.5;
            double roundedValue = 0.0;
            if (doubleValue.ToString().Contains('.'))
            {
                string s = doubleValue.ToString().Substring(doubleValue.ToString().IndexOf('.') + 1);
                if (Convert.ToInt32(s) == 5)
                {
                    roundedValue = doubleValue;
                }
                else
                {
                    roundedValue = Math.Round(doubleValue);
                }
            }
            Console.WriteLine("Result:      {0}", roundedValue);
   
