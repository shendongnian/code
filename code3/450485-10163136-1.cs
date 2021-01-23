    public class MyCustomClass
    {
        public static bool TryParse(object o, out string result)
        {
            result = null;
            if (o == null)
                return false;
            try
            {
                result = o.ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
