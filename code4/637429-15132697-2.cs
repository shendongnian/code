    // Discarded the class Foo, it's just a duplication of this
    class MyType
    {
        private string bar;
        [Editor(typeof(MyTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public string Bar
        {
            get { return bar; }
            set { bar = value; }
        }
    }
    // It was FooEditor, changed because now you have only MyType
    class MyTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            MyType myType = value as MyType;
            if (svc != null && myType != null)
            {
                using (FooForm form = new FooForm())
                {
                    form.Value = myType.Bar;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        myType.Bar = form.Value; // update object
                    }
                }
            }
            return value;
        }
    }
