    abstract class Bag<T> where T:marble {
        public void DumpBag()
        { 
    		// here you can use
            // (IEnumerable<string>)typeof(T).GetProperty("Nicknames").GetValue(null, null);
    	}
    }
    class RedBag : Bag<RedMarble> {
    }
    class BlueBag : Bag<BlueMarble> {
    }
