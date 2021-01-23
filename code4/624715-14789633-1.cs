    class Program
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(GroceryList));
            using (var reader = XmlReader.Create("groceriesList.xml"))
            {
                var list = (GroceryList)serializer.Deserialize(reader);
                // you could access the list items here
            }
        }
    }
