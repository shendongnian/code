    class Termocoppia
    {
        // be sure to add all of your values here...
        double[] t = { 1.019, 1.537, 2.059, ... };
        double[] d = { 10, 20, 30, ... };
        public double Calcola(double milliV, double _tempEx)
        {
            if (milliV <= t[0])
            {
                // handle special case (first)
                _tempEx = d[0];
            }
            else
            {
                bool success = false;
                int count = t.Length;
                // loop through all t values, test, and then calculate
                for (int idx = 1; idx < count; idx++)
                {
                    if (milliV <= t[idx])
                    {
                        _tempEx = d[idx] - 
                            ((t[idx] - milliV) / ((t[idx] - t[idx - 1]) / 10));
                        success = true;
                        break;
                    }
                }
                if (success == false)
                    throw new Exception("Unable to calculate _tempEX");
            }
            return _tempEx;
        }
    }
