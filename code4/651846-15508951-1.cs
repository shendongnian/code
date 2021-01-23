        private string SizeToString(int a, int b)
        {
            if (a == b)
            {
                return a.ToString();
            }
            else
            {
                return String.Format("{0}x{1}", a, b);
            }
        }
        var stringSizes = from t in _orderedCollection
                          select SizeToString(t.psizeW, t.psizeH);
