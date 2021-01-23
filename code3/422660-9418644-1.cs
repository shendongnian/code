    //Coded by Amen Ayach's DataClassBuilder @23/02/2012
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class HotKeyCls{
    
    	private bool _Ctrl;
    	public bool Ctrl{
    		get {
    			return _Ctrl;
    		}
    		set {
    			_Ctrl = value;
    		}
    	}
    
    	private bool _Shift;
    	public bool Shift{
    		get {
    			return _Shift;
    		}
    		set {
    			_Shift = value;
    		}
    	}
    
    	private bool _Alt;
    	public bool Alt{
    		get {
    			return _Alt;
    		}
    		set {
    			_Alt = value;
    		}
    	}
        	
    	private System.Windows.Forms.Keys _Key;
        public System.Windows.Forms.Keys Key
        {
    		get {
    			return _Key;
    		}
    		set {
    			_Key = value;
    		}
    	}
    
        public override string ToString()
        {
            return (Ctrl ? "Ctrl+" : "") + (Shift ? "Shift+" : "") + (Alt ? "Alt+" : "") + Key.ToString();           
        }
    }
