    public class StringEditor : UITypeEditor {
      public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
        return UITypeEditorEditStyle.Modal;
      }
      public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
        IWindowsFormsEditorService svc = (IWindowsFormsEditorService)
          provider.GetService(typeof(IWindowsFormsEditorService));
        if (svc != null) {
          svc.ShowDialog(new ConnectionDetailsForm());
          // update etc
        }
        return value;
      }
    }
