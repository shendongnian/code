    public partial class Form1 : Form
    {
        public class Example
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        public List<Example> elist = new List<Example>();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                elist.Add(new Example() { Id = i, Name = "Name" + i, Description = "Description " + i });
            }
            lookUpEdit1.Properties.DataSource = elist;
            lookUpEdit1.Properties.DisplayMember = "Name";
        }
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var item = lookUpEdit1.GetSelectedDataRow() as Example;
        }
    }
