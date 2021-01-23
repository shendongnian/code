    MonoTouch.ObjCRuntime.Selector description = new MonoTouch.ObjCRuntime.Selector ("description");
    foreach (UIView view in cell.Subviews) {
       MonoTouch.ObjCRuntime.Class c = new MonoTouch.ObjCRuntime.Class (view.GetType ());
       var name = NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (c.Handle, description.Handle));
       if (name == "UITableViewCellReorderControl") {
       }
    }
