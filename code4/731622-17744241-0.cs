                string cost = "535.8";
                string decplace = "3";
                decimal price = decimal.Round(Convert.ToDecimal(cost), Convert.ToInt32(decplace));
                //string.Format("{0:N2}", price);
                Console.WriteLine(string.Format("{0:N3}", price));
