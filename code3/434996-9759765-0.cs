    class Map
    {
       public static int[] RevPoints = { };
    }
    class P
    {
        void Main()
        {
            int[] maps = { };
            // Here the simple name Map means the type:
            foreach (int i in Map.RevPoints) {}
            // Here the simple name Map means the loop variable:
            foreach (int Map in maps) {}
        } 
    }
