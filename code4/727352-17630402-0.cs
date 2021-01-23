    public class Form1
    {
        private const string fileName = @"D:\MyNotes\MyNotes.rtf";
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(fileName))
                File.WriteAllText(fileName, "");
            richTextBox1.LoadFile(fileName);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            richTextBox1.SaveFile(fileName);
        }
    }
