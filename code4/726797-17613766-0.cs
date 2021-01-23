    public void MyMethod() {
    	//lookup the field via reflection
    	Type type = MyItem.GetType();
    	Console.WriteLine(type.GetField("MyField").GetValue(MyItem));
    	//simpler way than above using dynamic, but still at runtime
    	dynamic dynamicItem = MyItem;
    	Console.WriteLine(MyItem.MyField);
    }
