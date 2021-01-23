    public partial class Form1 : Form
    {
        List<string> InfoList = new List<string> 
                { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        const int labelNameLen = 3;
        public Form1() { InitializeComponent(); }
        private IEnumerable<Label> Labels
        {
            get
            {
                return this.Controls
                           .OfType<Label>()
                           .OrderBy(l => int.Parse(l.Name.Substring(labelNameLen)));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Label l in Labels)
            {
                if (i < InfoList.Count)
                    l.Text = InfoList[i++];
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int i = InfoList.Count;
            foreach (Label l in Labels)
            {
                if (i > 0)
                    l.Text = InfoList[--i];
            }
        }
    }
