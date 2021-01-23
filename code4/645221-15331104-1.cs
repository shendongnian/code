            for (int i = 0; i < XR.Length; i++)
            {
                SumRed += Math.Pow( (Math.Abs(oPoint.R - points[i].R)),2);
                SumGreen += Math.Pow((Math.Abs(oPoint.R - points[i].G)), 2);
                SumBlue += Math.Pow((Math.Abs(oPoint.R - points[i].B)), 2);
            }
