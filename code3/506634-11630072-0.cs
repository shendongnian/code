    public partial class Form1 : Form
    {
        List<Error> errors = new List<Error>();
        
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            errors = new List<Error>();
            listView1.Items.Clear();                                    
            foreach(Match m in Regex.Matches(richTextBox1.Text, @"(\(\s+|\s+\)|\[\s+|\s+\]|\{\s+|\s+\})", RegexOptions.IgnoreCase))
            {                           
                //you may decide to differentiate the msg according to the specific problem
                Error error = new Error(m, "Ommit Space between a bracket");
                this.errors.Add(error);
                listView1.Items.Add(error.msg);                
            }            
        }
    
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                Error error = errors[listView1.SelectedIndices[0]];
                Select(richTextBox1, error);
            }
        }
    
        private static void Select(RichTextBox rtb, Error e) {
            string o = rtb.Text;
            rtb.Clear();
            for (int i = 0; i < o.Length; i++)
            {
                if (i >= e.index && i <= e.index + e.length)
                {
                    rtb.SelectionColor = Color.White;
                    rtb.SelectionBackColor = Color.Red;
                }
                else
                {
                    rtb.SelectionColor = Color.Black;
                    rtb.SelectionBackColor = Color.White;
                }
                rtb.AppendText(o[i].ToString());
            }
        }              
    }
    
    public class Error
    {
    
        public int index;
        public int length;
        public string value;
        public string msg;
    
        public Error(Match m, string msg)
        {
            this.index = m.Index;
            this.length = m.Length;
            this.value = m.Value;
            this.msg = msg;
        }
    }
