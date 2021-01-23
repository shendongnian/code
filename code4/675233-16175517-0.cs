    private static Random rnd = new Random();
    
    public static void randomEvent(){
        int which = rnd.Next(1,events.Count);
        Debug.WriteLine("Which event: " + which);
        Debug.WriteLine("Count Events: "+ events.Count);
        ((Event) events[which-1]).write();
    }
