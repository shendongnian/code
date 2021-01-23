    public partial class Form1 : Form
    {
        private Thread thread;
        private byte[] encodedBytes2;
        private byte[] encodedBytes;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            string unicodeString = "Quick brown fox";
            encodedBytes = utf8.GetBytes(unicodeString);
            encodedBytes2 = new byte[20];
            encodedBytes2[0] = (byte)'r';
            encodedBytes2[1] = (byte)'e';
            
            for(int i = 0; i < 5; i++)
                textBox1.AppendText("ENCODED " + Encoding.ASCII.GetString(encodedBytes) + Environment.NewLine);
            for(int i = 0; i < 5; i++)
                textBox1.AppendText(" NOT ENCODED " + Encoding.ASCII.GetString(encodedBytes2) + Environment.NewLine);
            thread = new Thread(ThreadWork);
            thread.IsBackground = true;
            thread.Start();
        }
        private void ThreadWork()
        {
            for (int i = 0; i < 5; i++)
                textBox1.Invoke(new Action(() => textBox1.AppendText("THREAD ENCODED " + Encoding.ASCII.GetString(encodedBytes) + Environment.NewLine)));
            for (int i = 0; i < 5; i++)
                textBox1.Invoke(new Action(() => textBox1.AppendText("THREAD NOT ENCODED " + Encoding.ASCII.GetString(encodedBytes2) + Environment.NewLine)));
        }
    }
   
 
