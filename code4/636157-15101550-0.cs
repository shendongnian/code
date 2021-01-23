    public class Activity1 : Activity
    {
    	public static Timer Kundenerz = new Timer();
    	public static Timer Kundenerz2 = new Timer();
    	public static Timer Kundenerz3 = new Timer();
    
    	protected override void OnCreate(Bundle bundle)
    	{
    		base.OnCreate(bundle);
    		SetContentView(Resource.Layout.Main);
    		Kundenerz.Interval = 5000;
    		Kundenerz.Elapsed += Kundengroup;
    		Kundenerz.Enabled = true;
    		Kundenerz2.Interval = 5000;
    		Kundenerz2.Elapsed += Kundengroup2;
    		Kundenerz3.Interval = 5000;
    		Kundenerz3.Elapsed += Kundengroup3;
    	}
    
    	public void Kundengroup(object sender, ElapsedEventArgs e)
    	{
    		var textView1 = FindViewById<TextView>(Resource.Id.textView1);
    
    		Kundenerz.Enabled = false;
    		RunOnUiThread(() =>
    						  {
    							  textView1.Append("HI");
    							  textView1.Append("\r\n");
    						  });
    		Kundenerz2.Interval = 5000;
    		Kundenerz2.Enabled = true;
    	}
    
    	public void Kundengroup2(object sender, ElapsedEventArgs e)
    	{
    		var textView1 = FindViewById<TextView>(Resource.Id.textView1);
    		Kundenerz2.Enabled = false;
    		RunOnUiThread(() =>
    						  {
    							  textView1.Append("BYE");
    							  textView1.Append("\r\n");
    						  });
    		Kundenerz3.Enabled = true;
    	}
    
    	public void Kundengroup3(object sender, ElapsedEventArgs e)
    	{
    		var textView1 = FindViewById<TextView>(Resource.Id.textView1);
    		Kundenerz3.Enabled = false;
    		RunOnUiThread(() =>
    						  {
    							  textView1.Append("TRI");
    							  textView1.Append("\r\n");
    						  });
    		Kundenerz.Enabled = true;
    	}
    }
