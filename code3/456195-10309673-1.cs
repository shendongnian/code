    using System;
    using System.Linq;
    using MonoTouch.UIKit;
    using MonoTouch.Dialog;
    using MonoTouch.Foundation;
    
    namespace delete201204242A
    {
    	[Register ("AppDelegate")]
    	public partial class AppDelegate : UIApplicationDelegate
    	{
    		UIWindow _window;
    		UINavigationController _nav;
    		MyDialogViewController _rootVC;
    		
    		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    		{
    			_window = new UIWindow (UIScreen.MainScreen.Bounds);
    			
    			RootElement _rootElement = new RootElement ("LINQ root element") {
    				new Section ("List") {
    					from x in new Expense [] { new Expense () {Name="one"}, new Expense () {Name="two"}, new Expense () {Name="three"} }
    					select (Element)new BindingContext (null, x, x.Name).Root
    				}
    			};
    			
    			_rootVC = new MyDialogViewController (_rootElement);
    			_rootVC.EnableSearch = true;
    			_nav = new UINavigationController (_rootVC);
    			
    			_window.RootViewController = _nav;
    			
    			_window.MakeKeyAndVisible ();
    			
    			return true;
    		}
    		
    		public class MyDialogViewController : DialogViewController
    		{
    			public MyDialogViewController (RootElement root) : base (root) {}
    
    			public string SearchString { get; set; }			
    			public override void ViewDidAppear (bool animated)
    			{
    				base.ViewDidAppear (animated);
    				if (!string.IsNullOrEmpty (SearchString))
    					this.PerformFilter (SearchString);
    			}
    			public override void OnSearchTextChanged (string text)
    			{
    				base.OnSearchTextChanged (text);
    				SearchString = text;
    			}
    		}
    		
    		public class Expense
    		{
    			[Section("Expense Entry")]
    
    			[Entry("Enter expense name")]
    			public string Name;
    			[Section("Expense Details")]
    
    			[Caption("Description")]
    			[Entry]
    			public string Details;
    		}
    
    	}
    }
