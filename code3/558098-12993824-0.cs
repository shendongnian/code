    public class FileNamesEditor : UITypeEditor
    {
        private OpenFileDialog ofd;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                IWindowsFormsEditorService editorService =
                (IWindowsFormsEditorService)
                provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    ofd = new OpenFileDialog();
                    ofd.Multiselect = true;
                    ofd.Filter = "Word|*.docx|All|*.*";
                    ofd.FileName = "";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        return ofd.FileNames;
                    }
                }
            }
            return base.EditValue(context, provider, value);
        }
    }
