    using System;
    using Gdk;
    using Gtk;
    
    class GdkApp : Gtk.Window 
    {
    	public static void Main()
    	{
    		Application.Init();
    		new GdkApp();
    		Application.Run();
    	}
    
    	public GdkApp() : base("Simple drawing")
    	{
    		SetDefaultSize(230, 150);
    		DeleteEvent+=delegate {Application.Quit(); };
    		ShowAll();
    	}
    
    
    	protected override bool OnExposeEvent (EventExpose evnt)
    	{
    		bool ok = base.OnExposeEvent (evnt);
    		draw ();
    		return ok;
    	}
    
    	void draw()
    	{
    		Gdk.GC gc = new Gdk.GC ((Drawable)base.GdkWindow);
    		gc.RgbFgColor = new Gdk.Color (255, 50, 50);
    		gc.RgbBgColor = new Gdk.Color (0, 0, 0);
    		gc.SetLineAttributes (3, LineStyle.OnOffDash, 
    		                      CapStyle.Projecting, JoinStyle.Round);
    		Gdk.Point[] pts = new Gdk.Point[8];
    		pts [0] = new Gdk.Point (10, 50);
    		pts [1] = new Gdk.Point (15, 70);
    		pts [2] = new Gdk.Point (20, 80);
    		pts [3] = new Gdk.Point (25, 70);
    		pts [4] = new Gdk.Point (30, 80);
    		pts [5] = new Gdk.Point (40, 90);
    		pts [6] = new Gdk.Point (55, 85);
    		pts [7] = new Gdk.Point (75, 65);
    		base.GdkWindow.DrawLines (gc, pts);
    	}
    }
