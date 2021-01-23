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
		Item.GetItem(search).ParseRecipe();
	
	}
