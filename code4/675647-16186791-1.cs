    public class CustomListBox : ListBox
    {
        public event EventHandler ItemsCleared;
    
        public void ClearItems()
        {
            Items.Clear();
            if(this.ItemsCleared != null)
            {
                this.ItemsCleared(this, EventArgs.Empty);
            }
        }
    }
