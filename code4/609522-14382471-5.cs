	void Main()
	{
		items.Add(new Atom("Foo"));
		items.Add(new Atom("Bar"));
		items.Add(new Atom("Baz"));
		items.Add(new Atom("Qux" ));
		items.Add(new Recipe("Foobar", "Foo", "Bar"));
		items.Add(new Recipe( "Bazqux", "Baz", "Qux" ));
		items.Add(new Recipe( "Foobarbazqux", "Foobar", "Bazqux" ));
		
		string search = "Foobarbazqux";
		var item = Item.GetItem(search);
		Console.WriteLine("1 " + item.Name + " = " 
                                + String.Join(" + ", item.ParseRecipe().Select(x => "1 " + x.Name)));
	
	}
