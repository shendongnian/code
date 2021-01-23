    public class NullInt
    {
        public void ParseInt(string someString, ref int? someInt)
        {
            int i;
            if (int.TryParse(someString, out i))
            {
                someInt = i;
            }
        }
    }
