    static void Main(string[] args)
    {
        String timeString = "2011.01.02 22:06:52.091";
        string format = "yyyy.MM.dd HH:mm:ss.fff";
        double date = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture).ToOADate();
    }
}
