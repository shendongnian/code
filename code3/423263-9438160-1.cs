    static void Main() {
        List<TestItem> results = items.Where(MyFilter).ToList(); 
    static boolean MyFilter(TestItem item) {
        return item.Item1 == 12 && 
            item.Item2 != null && 
            item.Item2.SubItem == 65 && 
            item.Item3.Equals(anotherThingy)
    }
