    //Code tested in LinqPad
    void Main()
    {
        //Apples|3211|12
        //Markers|221|9
        //Turtle|1023123123|22
    
        //Create a list of items
        var items = new List<Item>
        {
            new Item { Description = "Apple", Id = 3211, Sequence = 12 },
            new Item { Description = "Markers", Id = 221, Sequence = 9 },
            new Item { Description = "Turtle", Id = 1023123123, Sequence = 22 }
        };
        
        
        //Get sorted list of Apple by Description
        var sortedByDescription = items.Where(i => i.Description == "Apple").OrderBy(i => i.Sequence);
        
        //Get sorted list of Turtle by Id
        var sortedById = items.Where(i => i.Id == 221).OrderBy(i => i.Sequence);
        
    }
    
    public class Item
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public int Sequence { get; set; }
    }
    
