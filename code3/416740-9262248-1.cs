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
