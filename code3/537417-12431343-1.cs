           static decimal Somemethod(int val)
            {
                var result = (decimal)new DataTable().Compute(string.Format("2*{0}+32-{1}", val, Math.Sin(6)), "");
                return result;
            }
