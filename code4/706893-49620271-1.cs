    public static IAccessible AsIAccessible(this UITestControl control)
    {
        var native = control.NativeElement as object[];
        return native[0] as IAccessible;
    }
