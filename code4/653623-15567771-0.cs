        public class TestClass
        {
            // decorate the property with a custom UITypeEditor
            [Editor(typeof(MyMultiSelectionEditor), typeof(UITypeEditor))]
            public long TestLong { get; set; }
            public int TestInt { get; set; }
            public TestEnum TestEnum { get; set; }
        }
        public class MyMultiSelectionEditor : UITypeEditor
        {
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                // adapt to your need
                if (!IsPropertyGridInMultiView(context))
                    return UITypeEditorEditStyle.None;
                return UITypeEditorEditStyle.Modal;
            }
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (IsPropertyGridInMultiView(context))
                {
                    // multi view, show my custom stuff
                    MessageBox.Show("hello from multi selection");
                }
                return base.EditValue(context, provider, value);
            }
            // gets a PropertyGrid instance from the context, if any
            private static PropertyGrid GetPropertyGrid(ITypeDescriptorContext context)
            {
                IServiceProvider sp = context as IServiceProvider;
                if (sp == null)
                    return null;
                Control view = sp.GetService(typeof(IWindowsFormsEditorService)) as Control;
                if (view == null)
                    return null;
                return view.Parent as PropertyGrid;
            }
            // determines if there is a PropertyGrid in the context, and if it's selection is multiple
            private static bool IsPropertyGridInMultiView(ITypeDescriptorContext context)
            {
                PropertyGrid pg = GetPropertyGrid(context);
                if (pg == null)
                    return false;
                return pg.SelectedObjects != null && pg.SelectedObjects.Length > 1;
            }
        }
