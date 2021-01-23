    public static void main() { 
    	MyClass1 obj = new MyClass1();
    	obj.MyEvent += (s, e) => { Console.WriteLine("Fired!"); };
    	obj.Method1();
    }
    
    public class MyClass1 {
    	public void Method1() {
    		MyClass2 obj = new MyClass2();
    		obj.MyEvent += (s, e) => { OnMyEvent(); };
    		obj.Method1();
    	}
    	public event EventHandler MyEvent;
    	private void OnMyEvent() {
    		var myEvent = MyEvent;
    		if (myEvent != null)
    			myEvent(this, EventArgs.Empty);
    	}
    }
    public class MyClass2 {
    	public void Method1() {
    		MyClass3 obj = new MyClass3();
    		obj.MyEvent += (s, e) => { OnMyEvent(); };
    		obj.Method1();
    	}
    	public event EventHandler MyEvent;
    	private void OnMyEvent() {
    		var myEvent = MyEvent;
    		if (myEvent != null)
    			myEvent(this, EventArgs.Empty);
    	}
    }
    public class MyClass3 {
    	public void Method1() {
    		// Raise event here that is handled in MyClass1?    
    		OnMyEvent();
    	}
    	public event EventHandler MyEvent;
    	private void OnMyEvent() {
    		var myEvent = MyEvent;
    		if (myEvent != null)
    			myEvent(this, EventArgs.Empty);
    	}
    }
