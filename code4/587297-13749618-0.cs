    class KHandler
    {
        public string name = "wut";
        public KHandler () : this ( "huh" ) {
        }
        public KHandler ( string val ) { 
            name = val;
        }
        
        static void Main()
        {
            KHandler handler = new KHandler();
            KHandler handler2 = new KHandler("something else");
            // handler.name = "huh";
            Console.WriteLine("All Good.");
        }
}
