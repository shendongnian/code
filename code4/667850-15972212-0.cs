    using Android.App;
    using Android.Content;
    using Android.Widget;
    using Android.OS;
    
    namespace Derrrp
    {
    	[Activity (Label = "Derrrp", MainLauncher = true)]
    	public class WritePrefsActivity : Activity
    	{
    		protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    
    			SetContentView (Resource.Layout.Write);
    
    			var prefs = Application.Context.GetSharedPreferences("MySharedPrefs", FileCreationMode.Private);
    			var prefsEditor = prefs.Edit();
    
    			var ed = FindViewById<EditText>(Resource.Id.editText1);
    			ed.AfterTextChanged += (sender, e) => {
    				prefsEditor.PutString("MyPref", e.Editable.ToString());
    				prefsEditor.Commit();
    			};
    
    			Button button = FindViewById<Button> (Resource.Id.myButton);
    			
    			button.Click += delegate {
    				var intent = new Intent(this, typeof(ReadPrefsActivity));
    				StartActivity(intent);
    			};
    		}
    	}
    }
