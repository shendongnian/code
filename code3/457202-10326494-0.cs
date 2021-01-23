    public class MyComboBox: ComboBox
    {
        public void AddItem(object item)
        {
            base.Items.Add(item);
            if (SelectedIndex == -1)
                SelectedIndex = 0;
        }
    }
