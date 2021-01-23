    public class MainVM
    {
        private void OnSelectedModelItemChanged()
        {
            this.SelectedItem = new ItemVM();
            this.SelectedItem.Model = this.SelectedModelItem;
        }
    }
