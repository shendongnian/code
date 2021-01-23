    public class Item
    {
        public int ID { get; set; }
        public int Number { get; set; }
    }
    List<Item> firstList = new List<Item>();
    List<Item> secondList = new List<Item>();
            
    List<Item> finalList = firstList.Join(
        secondList,
        item => item.ID,
        item => item.ID,
        (item, item1) => new Item() { ID = item.ID, Number = item.Number + item1.Number }).ToList();
