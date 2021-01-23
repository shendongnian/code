    //Make this static so it is accessible to your ApplyRules() method.
    public static bool solvedp1 = false;
    public static void ApplyRules()
    {
        if (Level.Rooms[0, 0].GetItem("Red Gem") != null
            & Level.Rooms[1, 0].GetItem("Blue Gem") != null
            & solvedp1 == false)
        {
            Console.Clear();
            Console.WriteLine("You put the gem in its correct place. As soon as the gem is in position, you feel a shiver and a warm feeling enters your toes and passes through your whole body. The strange feeling in the room is gone. You hear a lock unlocking and a door shrieking as it opens..");
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            solvedp1 = true;
        }
    }
