    class Text {
        public static Regex rx = new Regex(@" (PREVID|ACTID\=([0-9]+)) ");
        private Text prv; // previous article
        private string ot; // original text
        private int id; // act id on text
        private Semaphore isComputed = new Semaphore(0, 1);
        public int ActID {
            get {
                isComputed.WaitOne();
                int _id = id;
                isComputed.Release();
                return _id;
            }
        }
        public bool ProcessText() {
            var mx = rx.Match(ot);
            var prev = mx.Groups [1].Value == "PREVID";
            if(prev)
                id = prv == null ? 0 : prv.ActID;
            else
                if(!int.TryParse(mx.Groups [2].Value, out id))
                    throw new Exception(string.Format(@"Incorrect article id ""{0}""", mx.Groups [0].Value));
            isComputed.Release();
            return !prev;
        }
        public Text(string original_text, Text previous) {
            prv = previous;
            ot = original_text;
        }
    }
    public static void Main(String [] args) {
        // same random stream (for debugging)
        var rnd = new Random(1);
        var noise = @"These references are usually independent, but occasionally";
        // some noise text
        var bit = new Func<string>(() =>
            noise.Substring(0, rnd.Next(noise.Length)));
        // random article
        var text = new Func<string>(() =>
            string.Format(@"{0}{1}{2}", bit(),
                rnd.Next() % 2 == 0 ? " PREVID "
                                    : string.Format(@" ACTID={0} ", rnd.Next()), bit()));
        // random data input
        var data = new List<Text>();
        Text prv = null;
        for(var n = 0; n < 1000000; n++)
            // producer / consumer is better to parallelize load data step
            data.Add(prv = new Text(text(), prv));
        Console.Write("Press key to start...");
        Console.ReadKey();
        // parallel processing
        Console.WriteLine("{0} unique ID's", data.AsParallel().Where(n => n.ProcessText()).Count());
        Console.WriteLine("Process completed.");
    }
