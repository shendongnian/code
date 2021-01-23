    [Editor(typeof(MyEnumEditor), typeof(UITypeEditor))]
    public enum My_Enum
    {
        NUM1 = 0,
        NUM2 = 1,
        NUM3 = 2,
        [Browsable(false)]
        NUM4 = 3,
        NUM5 = 4,
        NUM6 = 5,
        NUM7 = 6,
        DEF
    }
    public class MyEnumEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private bool _cancel;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _cancel = false;
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            ListBox listBox = new ListBox();
            listBox.IntegralHeight = true;
            listBox.SelectionMode = SelectionMode.One;
            listBox.MouseClick += OnListBoxMouseClick;
            listBox.KeyDown += OnListBoxKeyDown;
            listBox.PreviewKeyDown += OnListBoxPreviewKeyDown;
            Type enumType = value.GetType();
            if (!enumType.IsEnum)
                throw new InvalidOperationException();
            foreach (FieldInfo fi in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                object[] atts = fi.GetCustomAttributes(typeof(BrowsableAttribute), true);
                if (atts != null && atts.Length > 0 && !((BrowsableAttribute)atts[0]).Browsable)
                        continue;
                int index = listBox.Items.Add(fi.Name);
                if (fi.Name == value.ToString())
                {
                    listBox.SetSelected(index, true);
                }
            }
            _editorService.DropDownControl(listBox);
            if ((_cancel) || (listBox.SelectedIndices.Count == 0))
                return value;
            return Enum.Parse(enumType, (string)listBox.SelectedItem);
        }
        private void OnListBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _cancel = true;
                _editorService.CloseDropDown();
            }
        }
        private void OnListBoxMouseClick(object sender, MouseEventArgs e)
        {
            int index = ((ListBox)sender).IndexFromPoint(e.Location);
            if (index >= 0)
            {
                _editorService.CloseDropDown();
            }
        }
        private void OnListBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _editorService.CloseDropDown();
            }
        }
    }
