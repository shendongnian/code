    public class whatever
    {
            static Random rand = new Random(Guid.NewGuid().GetHashCode());
            // or use new Random(); 
    
            public int losowanie(int w)
            {
                int s = w - 1;
                return rand.Next(0, s);
            }
    }
