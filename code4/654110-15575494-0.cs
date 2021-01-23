    public interface IGeneralPropertyMap<out T> {} // a class can't be covariant, so 
                                            // we need to introduce an interface...
    
    public class GeneralPropertyMap<T> : IGeneralPropertyMap<T> {} // .. and have our class
                                                                // inherit from it
    
    //now our method becomes something like
    private void TakeGeneralPropertyMap<T>(IList<IGeneralPropertyMap<T>> maps){}
    
    // and you can do
    	var maps = new List<IGeneralPropertyMap<Object>> {
    		new GeneralPropertyMap<String>(),
    		new GeneralPropertyMap<Regex>()
    	};
    	//And finally pass the array in.
    	TakeGeneralPropertyMap<Object>(maps);
