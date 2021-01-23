    public enum State
    {
        AL, GA, FL, SC, TN, MI
    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        // Converts properties to string array
        public string[] ToListViewItem()
        {
            return new string[] {
                ID.ToString("00000"),
                Name,
                State.ToString() };
        }
    }
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //Setup list view column headings and widths
            listView1.Columns.Add("ID", 48);
            listView1.Columns.Add("Name", 300);
            listView1.Columns.Add("State", 48);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Create a list
            List<Person> list = new List<Person>();
            // Fill in some data
            list.Add(new Person() { ID=1001, Name="John", State=State.TN });
            list.Add(new Person() { ID=1002, Name="Roger", State=State.AL });
            list.Add(new Person() { ID=1003, Name="Samantha", State=State.FL});
            list.Add(new Person() { ID=1004, Name="Kara", State=State.MI});
            // Fill in ListView from list
            PopulateListView(list);
        }
        void PopulateListView(List<Person> list)
        {
            listView1.SuspendLayout();
            for(int i=0; i<list.Count; i++)
            {
                // create a list view item
                var lvi = new ListViewItem(list[i].ToListViewItem());
                // assign class reference to lvi Tag for later use
                lvi.Tag = list[i];
                // add to list view
                listView1.Items.Add(lvi);
            }
            //This adjust the width of 1st column to fit data.
            listView1.Columns[0].Width=-1;
            listView1.ResumeLayout();
        }
    }
