    class MyComparer:Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            var xL = x.Split().Last();
            var yL = x.Split().Last();
            long xN;
            long yN;
            if (long.TryParse(xL,out xN) && long.TryParse(yL,out yN))
            {
                return xN.CompareTo(yN);
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
