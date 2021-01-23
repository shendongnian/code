    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int alloc = AllocConsole(); // Grab a new console to write to
            if (alloc != 1)
            {
                MessageBox.Show("Failed");
                return;
                }
            Console.WriteLine("test");
            Console.WriteLine("Adam");
            string input = Console.ReadLine();
            Console.WriteLine(input);
            // Do other funky stuff
            // When done
            FreeConsole();
        }
    }
