    class MyComparer:Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            var xL = xparts[xparts.Length - 1];
            long xN;
            if (long.TryParse(xL,out xN))
            {
                xparts[xparts.Length - 1] = xN.ToString().PadLeft(20,'0');
            }
            var yL = yparts[yparts.Length - 1];
            long yN;
            if (long.TryParse(yL, out yN))
            {
                yparts[yparts.Length - 1] = yN.ToString().PadLeft(20, '0');
            }
            var x2=String.Join(" ", xparts);
            var y2 = String.Join(" ", yparts);
            return x2.CompareTo(y2);
        }
    }
