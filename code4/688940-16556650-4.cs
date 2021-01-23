        static Stopwatch sw;
        static void Main(string[] args)
        {
            using (var wc = new WebClient()) {
                sw = new Stopwatch();
                sw.Start();
                wc.DownloadDataCompleted +=wc_DownloadDataCompleted;
                wc.DownloadDataAsync(new Uri("http://www.stackoverflow.com"));
                
            }
            Console.ReadLine();
        }
        static void wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            sw.Stop();
            Console.WriteLine("Elapsed time (ms): " + sw.ElapsedMilliseconds);
        }
