	using Gtk;
	using System;
	
	class ToggleButtons
	{
		public ToggleButtons()
		{
			Gtk.Application.Init();
			Builder Gui = new Builder();
			Gui.AddFromFile("togglebuttons.xml");
			Gui.Autoconnect(this);
			Gtk.Application.Run();
		}
		static void onDeleteEvent(object o, DeleteEventArgs args)
		{
			Application.Quit();
		}
		static void onExitButtonEvent(object o, EventArgs args)
		{
			Application.Quit();
		}
		public static void Main()
		{
			new ToggleButtons();
		}
	}
