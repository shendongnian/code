            string fmt = "yyyy-MM-dd";
            DateTime sd = DateTime.SpecifyKind(DateTime.Parse("02-Mar-2016"), DateTimeKind.Utc);
            for (int i = 0; i < 45; i++)
            {
                DateTime mat = sd.AddMonths(3).AddDays(i);
                int mnthCount = DateTimeSpan.CompareDates(sd, mat).Months;
                DateTime sdPlusMC = sd.AddMonths((int)mnthCount);
                double matInMnths;
                if (sdPlusMC == mat) matInMnths = mnthCount;
                else
                {
                    double diff = mat.Subtract(sdPlusMC).TotalDays;
                    matInMnths = mnthCount + (diff * 12 / 365.25);
                }
                Console.WriteLine("From {0} to {1} is {2} months.", sd.ToString(fmt), mat.ToString(fmt), matInMnths.ToString("0.00000000"));
            }
            Console.ReadLine();
