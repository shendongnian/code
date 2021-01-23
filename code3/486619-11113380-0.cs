            var x = new string[] { "2012/06/12", "20/06/2012", "111/111/1111" };
            foreach (var ds in x)
            {
                DateTime d = default(DateTime);
                try
                {
                    d = DateTime.Parse(ds, CultureInfo.GetCultureInfo("en-CA"));
                }
                catch (Exception ex)
                {
                    try
                    {
                        d = DateTime.ParseExact(ds, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                    }
                }
                if (d == default(DateTime))
                    Console.WriteLine("error");
                else
                    Console.WriteLine(d.ToString());
            }
