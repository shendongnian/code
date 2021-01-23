    // note how IPair<T> is covariant with T (the "out" keyword)
    public interface IPair<out T> {
    	 T First {get;}
    	 T Second {get;}
    }
        
    // I get no bonus points... I've had to touch Pair to add the interface
    // note that you can't make classes covariant or contravariant, so I 
    // could not just declare Pair<out T> but had to do it through the interface
    public class Pair<T> : IPair<T> {
    	public T First {get; set;}
    	public T Second {get; set;}
    	
     	// overriding ToString is not strictly needed... 
        // it's just to "prettify" the output of Console.WriteLine
    	public override string ToString() {
    		return String.Format("({0},{1})", First, Second); 
    	}    
    }
    public static class Application {
        // Swap now works with IPairs, but is fully generic, type safe
        // and contains no casts      
        public static IPair<T> Swap<T>(IPair<T> pair) {
    		return new Pair<T>{First=pair.Second, Second=pair.First};		
        }
        
        // as IPair is immutable, it can only swapped in place by 
        // creating a new one and assigning it to a ref
        public static void SwapInPlace<T>(ref IPair<T> pair) {
    		pair = new Pair<T>{First=pair.Second, Second=pair.First};
        }
        // now SwapAll works, but only with Array, not with List 
        // (my understanding is that while the Array's indexer returns
        // a reference to the actual element, List's indexer only returns
        // a copy of its value, so it can't be switched in place
        public static void SwapAll(IPair<object>[] pairs) {
    		for(int i=0; i < pairs.Length; i++) {
    		   SwapInPlace(ref pairs[i]);
    		}
        }
    }
