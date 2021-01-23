    namespace ConsoleApplication1
    {
        class Program
        {
            static int[] Item; //Fixed int Item[] to int[] Item
            static void Main(string[] args)
            {
                Add(3);
                Add(4);
                Add(6);
            }
    
         public static void Add(int x){
    
             if (Item == null)  // First time need to initialize your variable
             {
                 Item = new int[1];
             }
             else
             {
                 Array.Resize<int>(ref Item, Item.Length + 1);
             }
             Item[Item.Length-1] = x; //fixed Item.Length -> Item.Length-1
         }
    
        }
    }
