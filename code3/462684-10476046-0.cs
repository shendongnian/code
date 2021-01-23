    using System;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;
    using MonoTouch.ObjCRuntime;
    using System.Runtime.InteropServices;
    
    namespace delete20120506
    {
    	[Register ("AppDelegate")]
    	public partial class AppDelegate : UIApplicationDelegate
    	{
    		UIWindow window;
    
    		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    		{
    			window = new UIWindow (UIScreen.MainScreen.Bounds);
    			
    			// 
    			Target target = new Target ();
    			NSUrl url = new NSUrl ("http://xamarin.com/");
    			NSData nsData = NSData.FromString ("Hello");
    			
    			target.PerformSelector (new MonoTouch.ObjCRuntime.Selector 
    			                      ("TestSelUrl:withData:"), url, nsData);
    			
    			window.MakeKeyAndVisible ();
    			
    			return true;
    		}
    	}
    	
    	[Register ("Target")]
    	public class Target : NSObject
    	{
    		public Target () : base (NSObjectFlag.Empty) {}
    		
    		[Export("TestSelUrl:withData:")]
    	    void TestSelUrlWithData(NSUrl url, NSData nsData)
    	    {
    			Console.WriteLine ("In TestSelUrlWithData");
    			Console.WriteLine (url.ToString ());
    			Console.WriteLine (nsData.ToString ());
    			return;
    		}
    		
    		[DllImport ("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
    		public static extern void void_objc_msgSend_intptr_intptr_intptr (IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    		
    		[DllImport ("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
    		public static extern void void_objc_msgSendSuper_intptr_intptr_intptr (IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    		
    		
    		public virtual void PerformSelector (MonoTouch.ObjCRuntime.Selector sel, 
    		                                      NSObject arg1, NSObject arg2)
    		{
    			if (this.IsDirectBinding)
    			{
    				void_objc_msgSend_intptr_intptr_intptr (this.Handle, 
    					Selector.GetHandle ("performSelector:withObject:withObject:"),
    					sel.Handle, arg1.Handle, arg2.Handle);
    			}
    			else
    			{
    				void_objc_msgSendSuper_intptr_intptr_intptr (this.SuperHandle,
    					Selector.GetHandle ("performSelector:withObject:withObject:"), sel.Handle, 
    				    arg1.Handle, arg2.Handle);
    			}
    		}
    	}
    }
