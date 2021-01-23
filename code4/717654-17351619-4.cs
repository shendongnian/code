    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xVal, yVal;
            var xIsNumeric = int.TryParse( x, out xVal );
            var yIsNumeric= int.TryParse( y, out yVal );
    
            if (xIsNumeric && yIsNumeric)
                return xVal.CompareTo(yVal);
            if (!xIsNumeric && !yIsNumeric)
                return x.CompareTo(y);
            if (xIsNumeric )           
                return -1;
            return 1;   
        }
    }
