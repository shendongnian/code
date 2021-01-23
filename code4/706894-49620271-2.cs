    public static IAccessible AsIAccessible(this WinControl control)
    {
        var native = control.NativeElement as object[];
        return native[0] as IAccessible;
    }
