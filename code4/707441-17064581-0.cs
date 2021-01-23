    class Program
    {
        public static void Main()
        {
            var type = typeof(System.Windows.Forms.PowerStatus);
            foreach (PropertyInfo prop in type.GetProperties(
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic))
            {
                Console.WriteLine(prop.Name + "\t\t"
                    + prop.GetValue(null, null));
            }
            foreach (PropertyInfo prop in type.GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic))
            {
                Console.WriteLine(prop.Name + "\t\t" + prop.GetValue(
                    System.Windows.Forms.SystemInformation.PowerStatus, null));
            }
        }
    }
