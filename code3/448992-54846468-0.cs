    public static double Miidi(double[] list)
    {
        bool isEmpty = !list.Any();
        if (isEmpty)
        {
            return 0;
        }
        else
        {
            double avg = list.Average();
            double closest = 100;
            double shortest = 100;
            {
                for ( int i = 0; i < list.Length; i++)
                {
                    double lgth = list[i] - avg;
                    if (lgth < 0)
                    {
                        lgth = lgth - (2 * lgth);
                    }
                    else
                        lgth = list[i] - avg;
                    if (lgth < shortest)
                    {
                        shortest = lgth;
                        closest = list[i];
                    }
                }
            }
            
            return closest;
        }
    }
