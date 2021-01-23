    interface IGameItem
    {
        int AnimatedField { get; set; }
    }
    
    class GameItem : IGameItem
    {
        public int AnimatedField { get; set; }
    }
    
    class Animation
    {
        public IGameItem Item { get; set; }
    
        public void Update()
        {
            if (Item.AnimatedField == 0)
            {
                Item.AnimatedField = 5;
            }
            else
            {
                Item.AnimatedField = Item.AnimatedField + Item.AnimatedField;
            }
        }
    }
