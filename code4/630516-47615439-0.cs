    public class MyControlDesigner : ControlDesigner
    {
        protected override void OnCreateHandle()
        {
            base.OnCreateHandle();
            var property = TypeDescriptor.GetProperties(this.Control)["BackgroundImage"];
            var resourceEditorSwitch = property.GetEditor(typeof(UITypeEditor)) as UITypeEditor;
            var editorToUseField = resourceEditorSwitch.GetType().GetProperty("EditorToUse",
                BindingFlags.NonPublic | BindingFlags.Instance);
            var editorToUse = editorToUseField.GetValue(resourceEditorSwitch);
            var resourcePickerUIField = editorToUse.GetType().GetField("resourcePickerUI",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic);
            var resourcePickerUI = (Form)Activator.CreateInstance(resourcePickerUIField.FieldType);
            ModifyForm(resourcePickerUI);
            resourcePickerUIField.SetValue(editorToUse, resourcePickerUI);
        }
        void ModifyForm(Form f)
        {
            var resourceContextTableLayoutPanel = GetControl<TableLayoutPanel>(f, "resourceContextTableLayoutPanel");
            var resourceList = GetControl<ListBox>(f, "resourceList");
            resourceContextTableLayoutPanel.Controls.Remove(resourceList);
            var tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            List<string> list = new List<string>();
            var textBox = new TextBox() { Dock = DockStyle.Fill, Margin = resourceList.Margin };
            Action<string> applyFilter = (s) =>
            {
                if (string.IsNullOrEmpty(s))
                {
                    resourceList.BeginUpdate();
                    resourceList.Items.Clear();
                    resourceList.Items.AddRange(list.ToArray());
                    resourceList.EndUpdate();
                }
                else
                {
                    var list2 = list.Where(x => x.ToLower().StartsWith(s.ToLower())).ToList();
                    resourceList.BeginUpdate();
                    resourceList.Items.Clear();
                    resourceList.Items.Add("(none)");
                    resourceList.Items.AddRange(list2.ToArray());
                    resourceList.EndUpdate();
                }
                if (resourceList.Items.Count > 1)
                    resourceList.SelectedIndex = 1;
                else
                    resourceList.SelectedIndex = 0;
            };
            var resxCombo = GetControl<ComboBox>(f, "resxCombo");
            resxCombo.SelectedValueChanged += (s, e) =>
            {
                resxCombo.BeginInvoke(new Action(() =>
                {
                    if (resourceList.Items.Count > 0)
                    {
                        list = resourceList.Items.Cast<string>().ToList();
                        textBox.Text = string.Empty;
                    }
                }));
            };
            textBox.TextChanged += (s, e) => applyFilter(textBox.Text);
            textBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Up)
                {
                    e.Handled = true;
                    if (resourceList.SelectedIndex >= 1)
                        resourceList.SelectedIndex--;
                }
                if (e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    if (resourceList.SelectedIndex < resourceList.Items.Count - 1)
                        resourceList.SelectedIndex++;
                }
            };
            tableLayoutPanel.Controls.Add(textBox, 0, 0);
            resourceList.EnabledChanged += (s, e) =>
            {
                textBox.Enabled = resourceList.Enabled;
            };
            tableLayoutPanel.Controls.Add(resourceList, 0, 1);
            resourceContextTableLayoutPanel.Controls.Add(tableLayoutPanel, 0, 4);
        }
        T GetControl<T>(Control c, string name)
            where T : Control
        {
            return (T)c.Controls.Find(name, true).FirstOrDefault();
        }
    }
