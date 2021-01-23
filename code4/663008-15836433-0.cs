    public static double aggr(double[] dts, double[] vals, double std, double edd, DayOfWeek dayOfWeek)
        {
            int stdindex = 0;
            int eddindex = dts.Length;
            for (int k = 0; k < dts.Length; k++)
            {
                if (DateTime.FromOADate(dts[k]).DayOfWeek == dayOfWeek)
                {
                    if (dts[k] == std)
                    {
                        stdindex = k;
                    }
                    if (dts[k] == edd)
                    {
                        eddindex = k;
                    }
                }
            }
            return vals.Skip(stdindex).Take(eddindex - stdindex).Average();
        }
