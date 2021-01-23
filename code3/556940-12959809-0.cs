    // Some enums
    public enum Size { Small, Medium, Large }
    public enum Color { Red, Green, Blue, Purple, Brown }
    public enum Segment { Men, Women, Boys, Girls, Infants }
    // Fetches the actual list of items, where the object
    // item is the actual shirt, sock, shoe or whatever object
    static List<Tuple<Size, Color, Segment, object>> GetAllItems() {
        return new List<Tuple<Size, Color, Segment, object>> {
            Tuple.Create(Size.Small, Color.Red, Segment.Boys, (object)new { Name="I'm a sock! Just one sock." }),
            Tuple.Create(Size.Large, Color.Blue, Segment.Infants, (object)new { Name="Baby hat, so cute." }),
            Tuple.Create(Size.Large, Color.Green, Segment.Women, (object)new { Name="High heels. In GREEN." }),
        };
    }
    
    static void test() {
        var allItems = GetAllItems();
        // Lazy (non-materialized) definition of a "slice" of everything that's Small
        var smallQuery = allItems.Where(x => x.Item1 == Size.Small);
        // Lazy map where the key is the size and the value is 
        // an IEnumerable of all items that are of that size
        var sizeLookup = allItems.ToLookup(x => x.Item1, x => x);
        // Materialize the map as a dictionary the key is the size and the 
        // value is a list of all items that are of that size
        var sizeMap = sizeLookup.ToDictionary(x => x.Key, x => x.ToList());
        // Proof:
        foreach (var size in sizeMap.Keys) {
            var list = sizeMap[size];
            Console.WriteLine("Size {0}:", size);
            foreach (var item in list) {
                Console.WriteLine("  Item: {{ Size={0}, Color={1}, Segment={2}, value={3} }}",
                    item.Item1, item.Item2, item.Item3, item.Item4);
            }
        }
    }
