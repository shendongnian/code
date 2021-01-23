     public class TestClass
        {
            public bool[,] BoolArray
            {
                get;
                private set;
            }
            private List<Tuple<int, int>> negativeValues;
    
            public TestClass(int x, int y)
            {
                this.negativeValues = new List<Tuple<int, int>>();
                this.BoolArray = new bool[x, y];
            }
    
            public Tuple<int, int> GetPosition()
            {
                if (this.negativeValues.Count > 0)
                {
                    Random rand = new Random();
                    return this.negativeValues[rand.Next(this.negativeValues.Count - 1)];
                }
                else
                    return null;
            }
    
    
    
            public bool this[int x, int y]
            {
                get
                {
                    return this.BoolArray[x, y];
                }
    
                set
                {
                    if (!value)
                        negativeValues.Add(new Tuple<int, int>(x, y));
    
                    this.BoolArray[x][y] = value;
                }
            }
        }
