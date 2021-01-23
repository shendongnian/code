            public static double ParseDouble(string input)
            {
                // unify string (no spaces, only . )
                string output = input.Trim().Replace(" ", "").Replace(",", ".");
                // split it on points
                string[] split = output.Split('.');
                if (split.Count() > 1)
                {
                    // take all parts except last
                    output = String.Join("", split.Take(split.Count() - 1).ToArray());
                    // combine token parts with last part
                    output = String.Format("{0}.{1}", output, split.Last());
                }
                // parse double invariant
                double d = Double.Parse(output, CultureInfo.InvariantCulture);
                return d;
            }
