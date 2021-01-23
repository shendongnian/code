    public class MyCombo : ToolStripComboBox
    {
        [SettingsBindable(true)]
        public int SelectedIndex
        {
            get { return ComboBox.SelectedIndex; }
            set { ComboBox.SelectedIndex = value; }
        }
    }
