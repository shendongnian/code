    public static class Program
    {
        private static void Main()
        {
            Stuff stuff = new Stuff();
            string response;
            response = stuff[Stuff.Beep.HeyHo]; // response 1
            response = stuff[Stuff.Beep.LetsGo]; // response 2
        }
    }
