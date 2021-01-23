    namespace Your.App
    {
    //correct implementation of the State Pattern
    	interface IClipboard
    	{
    		void Copy();
    		void Paste();
    	}
    	class MyCustomClipboard : IClipboard
    	{
    		public void Copy() { /*your special code*/ }
    		public void Paste() { /*your code again*/ }
    	}
    	class DefaultClipboard : IClipboard
    	{
    		public void Copy() { /*default code*/ }
    		public void Paste() { /*default code again*/ }
    	}
    	public class StateClass
    	{
    		IClipboard State { get; set; }
    		public StateClass()
    		{
    			CurrentlyEditing = false;
    		}
    		bool _currentlyEditing;
    		public bool CurrentlyEditing
    		{
    			get { return _currentlyEditing; }
    			set
    			{
    				_currentlyEditing = value;
    				if(_currentlyEditing)
    					State = new DefaultClipboard();
    				else
    					State = new MyCustomClipboard();
    			}
    		}
    	}
    }
