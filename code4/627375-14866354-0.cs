    public class CustomComboBox : ComboBox
    {
        int currentlySelectedIndex = -1;
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            if (this.SelectedIndex != -1)
            {
                // Check if we shouldn ignore it:
                object currentlySelectedItem = this.Items[this.SelectedIndex];
                if (ShouldIgnore(currentlySelectedItem))
                {
                    Console.WriteLine("Ignoring it! Resetting the index.");
                    this.SelectedIndex = currentlySelectedIndex;
                }
            }
            base.OnSelectionChangeCommitted(e);
        }
        protected virtual bool ShouldIgnore(object selectedItem)
        {
            // This is a category if it starts with a space. 
            return !selectedItem.ToString().StartsWith(" ");     
        }
        protected override void OnDropDown(EventArgs e)
        {
            // Save the current index when the drop down shows:
            currentlySelectedIndex = this.SelectedIndex;
            
            base.OnDropDown(e);
        }
    }
