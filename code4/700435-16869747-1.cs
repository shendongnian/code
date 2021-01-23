       public Form1()
        {
            InitializeComponent();
            Win32.AllocConsole();  //Allocates a new console for current process.
        }
        private void button1_Click(object sender, EventArgs e) // on button click we write text to console 
        {
            Console.WriteLine(richTextBox1.Text); // write RTB text to console 
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)  // add form closing event 
        {
            Win32.FreeConsole(); // Free the console.
        }
