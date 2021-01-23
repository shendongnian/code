    public class Robot 
    {
        private static const int MAX_ROBOTS = 100;
        private static bool[] usedIds = new bool[MAX_ROBOTS];
        public int Id { get; set; }
 
        public Robot()
        {
             this.Id = GetFirstUnused();             
        }
        private static int GetFirstUnused()
        {
             int foundId = -1;
             for(int i = 0; i < MAX_ROBOTS; i++)
             {
                 if(usedIds[i] == false)
                 {
                     foundId = usedIds[i];
                     usedIds[i] = true;
                     break;
                 }
             }
             return foundId;
        }
    }
