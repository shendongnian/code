    public static double aggr(double[] dts, double[] vals, double std, double edd, DayOfWeek dayOfWeek)
        {
             int stdindex = 0;
            int eddindex = dts.Length;
            List<double> newDts = new List<double>();
            List<double> newVals = new List<double>();
            // Use only values that meet criteria
            for (int k = 0; k < dts.Length; k++)
            {
                if (DateTime.FromOADate(dts[k]).DayOfWeek == dayOfWeek)
                {
                    newDts.Add(dts[k]);
                    newVals.Add(vals[k]);
                }
            }
            // Loop through dates that met the criteria
            for (int k = 0; k < newDts.Count; k++)
            {
                if (newDts[k] == std)
                {
                    stdindex = k;
                }
                if (newDts[k] == edd)
                {
                    eddindex = k;
                }
            }
            return newVals.Skip(stdindex).Take(eddindex - stdindex).Average();
        }
