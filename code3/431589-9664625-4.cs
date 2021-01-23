    static void Main(string[] args)
    {
        var Response = System.Console.Out;
        var Hotels = new[]{1, 2, 3, 4};
        var Hotel = 0;
        Response.Write("RES " + Hotels.Count() + "<br />");
        if (Hotels.Count() > 0)
        {
            Hotel = Hotels.First();
        }
        Response.Write("RES " + Hotels.Count() + "<br />");
        Response.Write("RES " + Hotels.Count() + "<br />");
        
        Console.WriteLine( "Hotel: " + Hotel);
    }
