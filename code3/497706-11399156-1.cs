    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string a = null;
                    a.ToString();
                }
                catch (Exception ex)
                {
                    var s = ex.StackTrace;
                    Console.WriteLine(ex.Source);
                    int st = s.LastIndexOf("line");
                    Console.WriteLine(s.Substring(st, s.Length - st));
                }
            }
        }
