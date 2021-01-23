    class Player
    {
        Item item;
        public Player(Item item)
        {
            this.item = item; // store reference to item here, it will point to the same object you used for construction, no copying needed later
        }
    }
