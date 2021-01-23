    public class ItemSelectionDemo
    {
        public void ItemSelected(object sender, EventArgs e)
        {
            MyObject item = (MyObject)MyListView.SelectedItem;
            Debug.WriteLine("Selected item Id: " + item.id);
            Debug.Writeline("Selected item Name: " + item.name);
        }
    }
    public class MyObject
    {
        public int id;
        public string name;
    }
