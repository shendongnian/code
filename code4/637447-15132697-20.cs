    class FooEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            Foo foo = value as Foo;
            if (svc != null && foo != null)
            {
                using (FooForm form = new FooForm())
                {
                    form.Value = foo.Value;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        // Updates the value of the property Value
                        // of the property we're editing. 
                        foo.Value = form.Value;
                    }
                }
            }
            // In this case we simply return the original property
            // value, the property itself hasn't been changed because
            // we updated the value of an inner property
            return value;
        }
    }
