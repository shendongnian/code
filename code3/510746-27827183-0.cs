    static class Comparison
    {
        static class Of<T>
        {
            static public readonly Func<T, T, int> Compare;
            static Of()
            {
                var type = typeof(T);
                if(type == typeof(string))
                {
                    Comparison.Of<T>.Compare = (Func<T, T, int>)(object)new Func<string, string, int>((x, y) => x.CompareTo(y));
                }
                else if(type == typeof(int))
                { 
                  //... can generated dynamically with expression or dynamicmethod.
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
        static public int Compare<T>(T x, T y)
        {
            return Comparison.Of<T>.Compare(x, y);
        }
    }
    var a = "1";
    var b = "2";
    Comparison.Compare(a, b); //generic parameter is infered.
