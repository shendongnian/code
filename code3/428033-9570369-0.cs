    class Player
    {
        public string name;
        public int location;
        public List<Item> inventory = new List<Item>();
        public string[] possibleActions = new string[] { "move", "m", "look", "l", "take", "t", "drop", "d", "use", "u", "inventory", "i", "help", "h", "quit", "exit", "save", "load", "name" };
        /// <summary>
        /// Player action, array of predicate and target
        /// </summary>
        /// <param name="aAction"></param>
        /// <returns></returns>
        public void Do(string aText)
        {
            // ...
        }
        public void MoveTo(string location)
        {
            // ...
        }
        public void LookAt(string noun)
        {
            // ...
        }
        public void PickUpItem(string item)
        {
            // ...
        }
        public void DropItem(string item)
        {
            // ...
        }
        public void RemoveInventoryItem(string item)
        {
            // ...
        }
        public void UseItem(string item)
        {
            // ...
        }
        public void ListInventory()
        {
            // ...
        }
        public void ListActions()
        {
            // ...
        }
        /// <summary>
        /// Check the legitmacy of the action
        /// </summary>
        /// <param name="aText"></param>
        /// <returns></returns>
        public bool IsAction(string aText)
        {
            // ...
        }
        public void QuitPrompt()
        {
            // ...
        }
    }
