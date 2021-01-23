    using System;
    using System.Drawing;
    using MonoMac.Foundation;
    using MonoMac.AppKit;
    
    namespace ChromiumTabs
    {
    	[BaseType (typeof (NSWindowController))]
    	interface CTTabWindowController {
    	}
	
	[BaseType (typeof (CTTabWindowController))]
	interface CTBrowserWindowController {
		[Export ("browser")]
		CTBrowser Browser { get;  }
		[Export ("initWithBrowser:")]
		IntPtr Constructor (CTBrowser browser);
	}
	[BaseType (typeof (NSObject))]
	interface CTBrowser {
		[Export ("addBlankTabInForeground:")]
		CTTabContents AddBlankTabInForeground (bool foreground);
		[Export ("createBlankTabBasedOn:")]
		CTTabContents CreateBlankTabBasedOn (CTTabContents baseContents);
	}
	[BaseType (typeof (NSDocument))]
	interface CTTabContents {
		[Export ("initWithBaseTabContents:")]
		IntPtr Constructor ([NullAllowed]CTTabContents baseContents);
		[Export ("viewFrameDidChange:")]
		void ViewFrameDidChange (RectangleF newFrame);
	}
    }
