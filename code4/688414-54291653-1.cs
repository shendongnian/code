    double checkSquareRoot(double x, double y)
            {
                var result = Math.Pow(x, y);
                
                if (x > 0)
                {
                    return result;
                }
                else
                {
                    return -1 * Math.Pow(-x, y);
                }
            }
