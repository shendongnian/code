    public class Game1
    {
        Item Loading;
        Item[] Stuff;
        public class Item
        {
            public bool visible = true;
        }
        public void LoadContent()
        {
            Loading = new Item();
            Stuff = new Item[2];
            Stuff[1] = new Item();
        }
        public void Update(DateTime gameTime)
        {
            Loading.visible = false;
            System.Diagnostics.Debug.WriteLine(Loading.visible); //prints false
            Stuff[1].visible = false;
            System.Diagnostics.Debug.WriteLine(Stuff[1].visible); //prints false
        }
    }
