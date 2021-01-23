    public class GiveContext<T> where T : Person
    {
    	public P MeYourPet<P>() where P : Pet
    	{
    		return default(P);
    	}
    }
    
    public static GiveContext<T> Give<T>(this T person) where T : Person
    {
    	return new GiveContext<T>();
    }
