    class MyTimeField 
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public MyTimeField(String timeString)
        {
            var stringParts = timeString.Split(":");
            if(stringParts.length != 2) throw ArgumentException();
            Hours = Int32.Parse(stringParts[0]);
            Minutes = Int32.Parse(stringParts[1]);
        }
        public override String ToString()
        {
            return Hours + ":" + Minutes;
        }
    }
