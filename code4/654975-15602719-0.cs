	public class GladeApp
	{
		public static void Main(string[] args)
		{
			new GladeApp ();
		}
		public GladeApp(){
			//System.Console.WriteLine ("Hello GTK");
			//System.Console.Read ();
			Gtk.Application.Init ();
			
			Glade.XML gxml = new XML (null,@"textPad.FirstTextpad.glade","window1",null);
		
			gxml.Autoconnect (this);
			
			Gtk.Application.Run ();
			//return 0;
		}
		public void btnExit_clicked_cb(System.Object sender,System.EventArgs e)
		{
			close (null,null);
		}
		public void close(System.Object sender, System.EventArgs e)
		{
			Application.Quit ();
		}
	}
    }
