    // ** using MonoTouch.ObjCRuntime; **
    private string GetClassName (IntPtr obj) {
        Selector description = new Selector ("description");
        Selector cls = new Selector ("class");
        IntPtr viewcls = Messaging.IntPtr_objc_msgSend (obj, cls.Handle);
        var name = NSString.FromHandle (Messaging.IntPtr_objc_msgSend (viewcls, description.Handle));
        return name;
    }
