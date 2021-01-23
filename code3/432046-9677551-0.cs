    static void Main(string[] args)
            {
                const string date = "1 03 2012";
    
                Console.WriteLine(Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern);
                Console.WriteLine(Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern);
                Console.WriteLine(Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern);
                Console.WriteLine(Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern);
    
                Console.WriteLine(DateTime.Parse(date));
                Console.WriteLine(Convert.ToDateTime(date));
    
    
                Console.ReadLine();
            }
