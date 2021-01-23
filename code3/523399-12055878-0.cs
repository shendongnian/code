    class Context : IDisposable {
    	[ThreadStatic]
    	private static Context _instance;
    	[ThreadStatic]
    	private static int _instanceCounter;
    
    	public static Context Instance() {
    		if (_instanceCounter == 0) {
    			_instance = new Context();
    		}
    		_instanceCounter++;
    		return _instance;
    	}
    
    	private static void Release() {
    		_instanceCounter--;
    		if (_instanceCounter == 0) {
    			if (_instance != null)
    				_instance.Dispose();
    			_instance = null;
    		}
    	}
    
    	public void Dispose() {
    		Release();
    	}
    }
    
    public class Test {
    	public void Test1() {
    		using (var context = Context.Instance()) {
    			// do something
    			Test2();
    		}
    	}
    
    	private void Test2() {
    		using (var context = Context.Instance()) {
    			// identical context as in Test1
    			// do something
    		}
    	}
    }
