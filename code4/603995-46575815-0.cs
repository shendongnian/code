    rivate SomeViewClass v;
    public void AttachView(object view, object context = null)
            {
                v = view as BomView;
                if (ViewAttached != null)
                    ViewAttached(this,
                       new ViewAttachedEventArgs() { Context = context, View = view });
            }
    
            public object GetView(object context = null)
            {
                return v;
            }
