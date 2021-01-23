    public class Items : List<Item> // Logo class can be anything, corresponds to your values
    {
        public Items() 
        {
            Add(new Item( 0, 3000000)); 
            Add(new Item(25, 1500000)); 
            Add(new Item(50, 2000000));
            // etc
        }
        /// <summary>
        /// Returns a random item based on value.
        /// </summary>
        /// <returns></returns>
        public Item GetRandomItem()
        {
            var sum = this.Sum(item => item.Value);
            var randomValue = new Random().Next(sum);
            // Iterate through itemsuntil found.
            var found = false;
            var itemIndex = 0;
            var visitedValue = 0;
            while (!found)
            {
                var item = this[itemIndex];
                if ((visitedValue + item.Value ) > randomValue)
                {
                    found = true;
                }
                else
                {
                    itemIndex++;
                    visitedValue += item.value;                }
            }
            return this[itemIndex];        
        }
