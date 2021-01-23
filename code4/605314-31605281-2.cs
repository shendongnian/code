    public partial class MainWindow: Gtk.Window
    {
    	/** Add a label to your project called lblPath **/
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
    			string files = System.Text.Encoding.UTF8.GetString (data);
				string file;
				string[] fileArray = files.Split ('\n');
				for (int i = 0; i < fileArray.Length - 1; i++) { //the last element is empty
					file = fileArray [i].Replace ("\r", "");
    				if (file.StartsWith("file://"))
						file = file.Substring(7);
					lblPath.Text += file + "\n";
				}
    		}
    	}
    }
