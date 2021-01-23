    public class UpDownValueEditor : UITypeEditor {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            IWindowsFormsEditorService editorService = null;
            if (provider != null) {
                editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }
            if (editorService != null) {
                NumericUpDown udControl = new NumericUpDown();
                udControl.DecimalPlaces = 0;
                udControl.Minimum = 0;
                udControl.Maximum = 127;
                udControl.Value = (UInt16)value;
                editorService.DropDownControl(udControl);
                value = (UInt16)udControl.Value;
            }
            return value;
        }
    }
