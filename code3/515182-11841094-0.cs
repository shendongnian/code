      static void Main(string[] args)
            {
                string startDt = "1-apr-2011";
                string endDt = "30-apr-2012";
                DateTime dt = Convert.ToDateTime(startDt);
                DateTime dt2 = Convert.ToDateTime(endDt);
                while (dt < dt2)
                {
                    var first = new DateTime(dt.Year, dt.Month, 1);
                    var last = new DateTime(dt.Year, dt.Month, 1).AddMonths(1).AddDays(-1);
                    Console.Write(String.Format("{0:dd-MMM-yyyy}", first));
                    Console.Write("== To == ");
                    Console.WriteLine(String.Format("{0:dd-MMM-yyyy}", last));
                    dt = dt.AddMonths(1);
                }
                Console.Read();
            }
