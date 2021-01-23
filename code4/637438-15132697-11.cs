    class MyStringEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            string text = value as string;
            if (svc != null && text != null)
            {
                using (FooForm form = new FooForm())
                {
                    form.Value = text;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        return form.Value;
                    }
                }
            }
            return value;
        }
    }
