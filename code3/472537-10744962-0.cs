        public class OrderComparer<T> : IComparer<string>
        {
            #region IComparer<string> Members
            public int Compare(string x, string y)
            {
                return GetOrderableValue(x.Split('-').First()).CompareTo(GetOrderableValue(y.Split('-').First()));
            }
            #endregion
            private int GetOrderableValue(string value)
            {
                string[] splitValue = value.Split('.');
                int orderableValue = 0;
                if (splitValue.Length.Equals(1))
                    orderableValue = int.Parse(splitValue[0]) * 1000;
                else if (splitValue.Length.Equals(2))
                    orderableValue = int.Parse(splitValue[0]) * 1000 + int.Parse(splitValue[1]) * 100;
                else if (splitValue.Length.Equals(3))
                    orderableValue = int.Parse(splitValue[0]) * 1000 + int.Parse(splitValue[1]) * 100 + int.Parse(splitValue[2]) * 10;
                else
                    orderableValue = int.Parse(splitValue[0]) * 1000 + int.Parse(splitValue[1]) * 100 + int.Parse(splitValue[2]) * 10 + int.Parse(splitValue[3]);
                return orderableValue;
            }
        }
