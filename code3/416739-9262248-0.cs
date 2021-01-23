    public class MyTodoListEntry
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> Information { get; set; }
        public MyTodoListEntry()
        {
            this.Information = new List<string>();
        }
        public override string ToString()
        {
            return this.Title;
        }
    }
    MyTodoListEntry entry = new MyTodoListEntry();
    entry.Title = "get food for dinner";
    entry.Information.Add("bread rolls");
    entry.Information.Add("bacond");
    entry.DueDate = new DateTime(2012,12,12);
    myListBox.Items.Add(entry);
    private void myListBox_Click(object sender, EventArgs e)
    {
        // get selected TodoList Entrie
        MyTodoListEntry selectedEntry = (MyTodoListEntry)myListBox.SelectedItem;
        // do something, for example populate another ListBox with selectedEntry
    }
