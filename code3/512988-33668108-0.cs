        private ConnectSqlForm()
        {
            InitializeComponent();
            cmbDatabases.TextChanged += UpdateAutoCompleteComboBox;
            cmbDatabases.KeyDown += AutoCompleteComboBoxKeyPress;
        }
       
        private void UpdateAutoCompleteComboBox(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if(comboBox == null)
            return;
            string txt = comboBox.Text;
            string foundItem = String.Empty;
            foreach(string item in comboBox.Items)
                if (!String.IsNullOrEmpty(txt) && item.ToLower().StartsWith(txt.ToLower()))
                {
                    foundItem = item;
                    break;
                }
            if (!String.IsNullOrEmpty(foundItem))
            {
                if (String.IsNullOrEmpty(txt) || !txt.Equals(foundItem))
                {
                    comboBox.TextChanged -= UpdateAutoCompleteComboBox;
                    comboBox.Text = foundItem;
                    comboBox.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                    comboBox.TextChanged += UpdateAutoCompleteComboBox;
                }
                comboBox.SelectionStart = txt.Length;
                comboBox.SelectionLength = foundItem.Length - txt.Length;
            }
            else
                comboBox.DroppedDown = false;
        }
        private void AutoCompleteComboBoxKeyPress(object sender, KeyEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.DroppedDown)
            {
                switch (e.KeyCode)
                {
                    case Keys.Back:
                        int sStart = comboBox.SelectionStart;
                        if (sStart > 0)
                        {
                            sStart--;
                            comboBox.Text = sStart == 0 ? "" : comboBox.Text.Substring(0, sStart);
                        }
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }
