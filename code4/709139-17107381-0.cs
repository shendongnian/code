    void Main() {
        var listFields = new string[] { "Field1", "Field2" };
        var listValues = new string[] { "value1", "value2" };
        // prepare & show dummy data
        var listItems = Enumerable.Range(1, 100).Select(aaIndex => new MyItem {
            Name = string.Format("item{0}", aaIndex),
            Field1 = string.Format("value{0}", aaIndex % 3),
            Field2 = string.Format("value{0}", aaIndex % 7)
        });
        listItems.Dump();
        // apply filtering
        var filtered = listItems.Where(aaItem => Enumerable.Range(0, listFields.Length).All(aaIndex => {
            var value1 = aaItem.GetType().GetProperty(listFields[aaIndex]).GetValue(aaItem, null);
            var value2 = listValues[aaIndex];
            if (value1 is IComparable) {
                return ((IComparable)value1).CompareTo(value2) == 0;
            }
            return Convert.ToString(value1) == Convert.ToString(value2);
        }));
        filtered.Dump();
    }
    // Define other methods and classes here
    class MyItem {
        public string Name { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
