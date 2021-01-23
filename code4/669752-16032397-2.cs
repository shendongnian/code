    class X
    {
        public static Item objA = new Item();
        ..., objB, objC, ..... ,.....,
    }
    ...
    List<Item> items = new List<Item>();
    foreach (var field in typeof(ListaUczniow).GetFields(BindingFlags.Static | BindingFlags.Public))
        if (field.Name.StartsWith("obj") && field.FieldType == typeof(Item))
            items.Add( (Item) field.GetValue(null) );
