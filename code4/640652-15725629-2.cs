    public void handleui(dynamic s)
	{
	    Application.Current.Dispatcher.Invoke(delegate
	                                              {
	                                                  btn1.Content = s.ToString();
	                                              });
	}
    Globals.Events["error"] += msg=> Console.WriteLine(msg);//logger perhaps
    Globals.Events["productb"] += handleui;//sub
    Globals.Events["productb"] -= handleui;//unsub    
    Globals.Events["productb"].Send("productbdata");//raise the event or publish to productb channel subscribers
    Globals.Events.Send("broadcast?");
