    public partial class Form1 : Form
    {
         private const int EM_GETLINECOUNT = 0xba;
         [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
         private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
    
    
         public Form1()
         {
            InitializeComponent();
         }
    
         private void textBox1_TextChanged(object sender, EventArgs e)
         {
            var numberOfLines = SendMessage(textBox1.Handle.ToInt32(), EM_GETLINECOUNT, 0, 0);
            this.textBox1.Height = (textBox1.Font.Height + 2) * numberOfLines;
         }
    } 
