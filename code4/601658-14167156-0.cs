    private void InsertarIntoDataBase()
    {
    	try 
    	{
    		Juego game = db.games.First(g => g.Id == anId);
    		Day d = new Day {
    						   DayNumber = this.Number,
    						   Game = game // This is a relationship. One Day has one game 
    						};
    		db.AddToDay(d);
    		db.SaveChanges();
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine(e);
    	}
    }
