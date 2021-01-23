	public class MyEditor: UITypeEditor {
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
			return UITypeEditorEditStyle.DropDown;
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
			IWindowsFormsEditorService  service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (service != null) {
                SomeControl ctrl = new SomeControl();
				ctrl.XYZ = ...
				service.DropDownControl(ctrl);
				value = ctrl.XYZ;
			}
			return value;
		}
