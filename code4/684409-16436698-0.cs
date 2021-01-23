    public partial class Form1 : Form
    {
        private bool FLAG_Selftimer = false;
        private bool FLAG_KeyPressed = false;
        private int pos = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var rtb = sender as RichTextBox;
            var point = rtb.SelectionStart;
            if (!FLAG_Selftimer)
            {
                rtb.Text = ReGenerateRTBText(rtb.Text);
                FLAG_KeyPressed = false;
            }
            else
            {
                point ++;
                FLAG_Selftimer = false;
            }
            rtb.SelectionStart = point;
        }
        private string ReGenerateRTBText(string Text)
        {
            string[] text = Regex.Split(Text,"\n");
            int lvl = 0;
            string newString = "";
            foreach (string line in text)
            {
                line.TrimStart(' ');
                newString += indentation(lvl) + line.TrimStart(' ') + "\n";
                if (line.Contains("{"))
                    lvl++;
                if (line.Contains("}"))
                    lvl--;
            }
            FLAG_Selftimer = true;
            return (!FLAG_KeyPressed) ? newString : newString.TrimEnd('\n');
        }
        private string indentation(int IndentLevel)
        {
            string space = "";
            if(IndentLevel>0)
                for (int lvl = 0; lvl < IndentLevel; lvl++)
                {
                        space += " ".PadLeft(8);
                }
            return space;
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FLAG_KeyPressed = true;
        }
    }
