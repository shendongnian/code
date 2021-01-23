    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;
    
    namespace Derrrp
    {
    	[Activity (Label = "ReadPrefsActivity")]			
    	public class ReadPrefsActivity : Activity
    	{
    		protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    
    			SetContentView(Resource.Layout.Read);
    
    			var tv = FindViewById<TextView>(Resource.Id.myTextView);
    			var button = FindViewById<Button>(Resource.Id.myButton);
    
    			var prefs = Application.Context.GetSharedPreferences("MySharedPrefs", FileCreationMode.Private);
    
    			button.Click += (sender, e) => {
    				tv.Text = prefs.GetString("MyPref", "");
    			};
    		}
    	}
    }
