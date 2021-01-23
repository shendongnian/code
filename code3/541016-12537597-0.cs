        static void Main(string[] args)
        {
            var parser = new MeasPropListParser<double>();
            var values = parser.GetValues("{1960, 1980, 0}, {1980, 0, 0}, {1960, 1980, 1990}");
        }
    
    
       public class MeasPropListParser<T>
        {
            private char[] comma = new char[] { ',' };
            private char[] rightBrace = new char[] { '}' };
    
            public T[,] GetValues(string input)        
            {
                var dims = GetDimensions(input);
                int rowCount = dims.Item1;
                int colCount = dims.Item2;
    
                T[,] array = new T[rowCount, colCount];
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                var rows = GetRows(input);
    
                for (int x = 0; x < rowCount; x++)
                {
                    var cols = new List<string>(rows[x].Split(comma, StringSplitOptions.RemoveEmptyEntries));
                    for (int y = 0; y < colCount; y++)
                    {
                        array[x, y] = (T)converter.ConvertFromString(cols[y]);
                    }
                    
                }
    
                return array;
            }
    
            private Tuple<int, int> GetDimensions(string input)
            {
                int rowCount = 0;
                int colCount = 0;
                foreach (var array in input.Trim().Split(rightBrace, StringSplitOptions.RemoveEmptyEntries))
                {
                    rowCount++;
                    if (colCount == 0)
                    {
                        colCount = array.Split(comma, StringSplitOptions.RemoveEmptyEntries).Length;
                    }
                }
                return new Tuple<int, int>(rowCount, colCount);
            }
    
            private List<string> GetRows(string input)
            {
                var list = new List<string>();
                foreach (var array in input.Trim().Split(rightBrace, StringSplitOptions.RemoveEmptyEntries))
                {
                    list.Add(array.Replace("{", "").Trim());
                }
                return list;
            }
        }
