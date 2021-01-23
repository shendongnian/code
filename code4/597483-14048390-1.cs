    public class ClassB {
    public event EventHandler MySpecialHook;
    public void SomeMethodDoingActionInB()
    {
     	// do whatever you need to.
     	// THEN, if anyone is listening (via the class A sample below)
     	// broadcast to anyone listening that this thing was done and 
     	// they can then grab / do whatever with results or any other 
     	// properties from this class as needed.
     	if( MySpecialHook != null )
         	MySpecialHook( this, null );
     } 
    }
    public class YourClassA
    {
    
       ClassB YourObjectToB;
    
       public YourClassA
       {
          // create your class
          YourObjectToB = new ClassB();
          // tell Class B to call your "NotificationFromClassB" method
          // when such event requires it
          YourObjectToB += NotificationFromClassB;
       }
    
       public void NotificationFromClassB( object sender, EventArgs e )
       {
          // Your ClassB did something that your "A" class needs to work on / with.
          // the "sender" object parameter IS your ClassB that broadcast the notification.
       }
    }
