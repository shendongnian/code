    internal class Program
    {
        private static void Main(string[] args)
        {
            double x, y;
            if (tryParseCoordinates("3,6\t2,4", out x, out y))
            {
                Debug.WriteLine(string.Format("X: {0}, Y:{1}",
                                              x.ToString(CultureInfo.InvariantCulture),
                                              y.ToString(CultureInfo.InvariantCulture)));
            }
        }
        private static bool tryParseCoordinates(string line, out double X, out double Y)
        {
            X = 0.0;
            Y = 0.0;
            string[] coords = line.Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
            if (coords.Length != 2)
            {
                return false;
            }
            bool xOk = double.TryParse(coords[0], out X);
            bool yOk = double.TryParse(coords[1], out Y);
            return xOk && yOk;
        }
    }
