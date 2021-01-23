    using Microsoft.VisualBasic;
    class Program
    {
        static void Main(string[] args)
        {
            var a = "234234324\r\n";
            int b = int.Parse(Conversion.Val(a).ToString());
        }
    }
