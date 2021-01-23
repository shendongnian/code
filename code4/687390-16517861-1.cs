    static class Program {
        static void Main() {
            var obj = new { A = "abc", B = 123 };
            System.Console.WriteLine(obj.GetHashCode());
        }
    }
