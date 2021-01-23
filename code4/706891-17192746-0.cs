    object[] native = 
      this.UIMap.UIMainWindow.UICustomControl.NativeElement as object[];
    if ((native[0] != null) && (native[0] is IAccessible)) {
        IAccessible a = native[0] as IAccessible;
        if (a is CustomControl)
            CustomControl control = (CustomControl)a;
    }
