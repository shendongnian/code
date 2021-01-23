    public abstract class MenuItemsPolicy{
        public abstract List<MenuItem> GetMenuItems();
        protected virtual MenuItem CreateMenuItem(string text, string url){
            //add parameter checks, etc.
            MenuItem item = new MenuItem();
            item.Text = text;
            item.NavigateUrl = url;
            return item;
        }
    }
