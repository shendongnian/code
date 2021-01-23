    public class Data
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Program
    {
        static object PropertyGet(object p, string propName)
        {
            Type t = p.GetType();
            PropertyInfo info = t.GetProperty(propName);
            if (info == null)
            {
                return null;
            }
            else
            {
                return info.GetValue(p, null);
            }
        }
        static void Main(string[] args)
        {
            var data = new Data() { Username = "Fred" };
            var x = PropertyGet(data, "Username");
            Console.Write(x ?? "NULL");
        }
    }
