    public class MenuItems
    {
        public static List<Menu> Items;
    
        static MenuItems()
        {
           Items = new List<Menu>();
           Items.Add(new Menu
           {
               Alt = "test item",
               ItemName = "item 1",
           });
           Items.Add(new Menu
           {
                Alt = "test item",
                ItemName = "item 2",
            });
         }
    }
