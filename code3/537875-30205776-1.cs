    private void SetLabelColumnWidth(int width)
    {
        FieldInfo fi = this.GetType().<strong>BaseType</strong>.GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic);
        object view = fi.GetValue(this);
        MethodInfo mi = view.GetType().GetMethod("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic);
    
        mi.Invoke(view, new object[] { width });
    }
