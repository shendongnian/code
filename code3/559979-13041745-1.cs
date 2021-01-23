    internal class GenericTypeEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService winFormEditorSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            
            using (MyForm editorForm = new MyForm())
            {
                if (winFormEditorSvc.ShowDialog(editorForm) == System.Windows.Forms.DialogResult.OK)
                    value = editorForm.ReturnObject;
            }
            return value; //this can be null if you wish
        }
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
    
