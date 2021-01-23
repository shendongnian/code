    class BirdCage<T> : ILoad<T> where T : Bird
    {
    	public void Put(T t)
    	{
    	}
    }
    ILoad<Bird> normalCage = new BirdCage<Bird>();
    normalCage.Put(new Dove()); //accepts any type of birds
    
    ILoad<Dove> doveCage = new BirdCage<Bird>();//Contravariance, Bird is less specific then Dove
    doveCage.Put(new Dove()); //only accepts doves
