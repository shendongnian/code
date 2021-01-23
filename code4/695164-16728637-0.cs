    public PewPew SomeMethod(Foo foo) {
        IList<Cat> cats = null;
    	IList<Food> foods = null;
    	
    	Task[] tasks = new tasks[2] {
    		Task.Factory.StartNew(() => { cats = GetAllTheCats(foo); }),
    		Task.Factory.StartNew(() => { food = GetAllTheFood(foo); })
    	};
    	
    	Task.WaitAll(tasks);
    
        return new PewPew
                   {
                       Cats = cats,
                       Food = food
                   };
    }
