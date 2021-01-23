    public class CustomListBox : ListBox
    {
        public event EventHandler ItemsCleared;
    
        public void ClearItems()
        {
            Items.Clear();
            Cleared(this, EventArgs.Empty);
        }
    }
