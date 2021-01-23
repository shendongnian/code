    foreach (DataRow newRow1 in dt.Rows)
            {
                string zipCode1 = newRow1[2].ToString();
                double latitude2 = Convert.ToDouble(newRow1[3]);
                double longitude2 = Convert.ToDouble(newRow1[4]);
                // Start minD at the max value
                double minD = double.MaxValue;
                foreach (DataRow newRow2 in dt2.Rows)
                {
                    if (newRow2[2].ToString().Equals(zipCode1))
                    {
                        newRow1[5] = newRow2[1].ToString();
                        double latitude = Convert.ToDouble(newRow1[3]);
                        double longitude = Convert.ToDouble(newRow1[4]);
                        double d = Math.Sqrt(Math.Abs(latitude - latitude2) * Math.Abs(latitude - latitude2) + Math.Abs(longitude - longitude2) * Math.Abs(longitude - longitude2));
                        minD = Math.Min(minD, d);
                        Console.WriteLine("Found match!");
                    }
                }
                Console.WriteLine("Min D: {0}", minD);
            }
