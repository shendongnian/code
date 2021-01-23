    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int pointer = 0;
            int index = 0;
            string keyword = txtComAuthor.Text;
            string shadow = richComByTemplate.Text;
            while (true)
            {
                //Searching in the copy/shadow 
                index = shadow.IndexOf(keyword, pointer, StringComparison.InvariantCultureIgnoreCase);
                //if keyword not found then the loop will break 
                if ((index == -1) || (String.IsNullOrEmpty(keyword)))
                {
                    break;
                }
                richComByTemplate.Select(index, keyword.Length);
                richComByTemplate.SelectionColor = Color.Red;
                richComByTemplate.SelectionFont = new System.Drawing.Font(richComByTemplate.Font, FontStyle.Bold);
                pointer = index + keyword.Length;
            } 
        }
    }
