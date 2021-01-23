    public partial class Form1 : Form
    {
        const int PAGE_SIZE = 64;   // in characters
        int position = 0;  // position in stream
        public Form1()
        {
            InitializeComponent();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            position = e.NewValue * PAGE_SIZE;
            ReadFile(position);    
        }
        private void ReadFile(int position)
        {
            using (StreamReader sr = new StreamReader(@"C:\test.txt"))
            {
                char[] chars = new char[PAGE_SIZE];
                sr.BaseStream.Seek(position, SeekOrigin.Begin);
                sr.Read(chars, 0, PAGE_SIZE);
                string text = new string(chars);
                richTextBox1.Text = text;
            }    
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(position);
        }
    }
