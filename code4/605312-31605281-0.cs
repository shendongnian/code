    public partial class MainWindow: Gtk.Window
    {
    	/** Add a label to your project called lbPath **/
    	public MainWindow () : base (Gtk.WindowType.Toplevel)
    	{
    		Build ();
    		//media type we'll accept
    		Gtk.TargetEntry [  ] target_table = 
    			new TargetEntry [  ] {
    			new TargetEntry ("text/uri-list", 0, 0),
    			new TargetEntry ("application/x-monkey", 0, 1),
    		};
    		Gtk.Drag.DestSet (lblPath, DestDefaults.All, target_table, Gdk.DragAction.Copy);
    		lblPath.DragDataReceived += new Gtk.DragDataReceivedHandler(OnLabelDragDataReceived);
    	}
    
    	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    	{
    		Application.Quit ();
    		a.RetVal = true;
    	}
    
    	void OnLabelDragDataReceived (object sender, Gtk.DragDataReceivedArgs args)
    	{
    		if (args.SelectionData.Length > 0) {
    			byte[] data = args.SelectionData.Data;
    			string filePath = System.Text.Encoding.UTF8.GetString (data);
    			lblPath.Text = filePath;
    		}
    	}
    }
