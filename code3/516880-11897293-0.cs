            public partial class Form1 : Form
            {
            private delegate int Callback(int text);
            private Callback mInstance;   // Ensure it doesn't get garbage collected
            [DllImport(@"C:\Visual Studio 2010\Projects\kalkulatorius\Debug\WHUU1.dll")]
            private static extern void SetCallback(Callback fn);
            [DllImport(@"C:\Visual Studio 2010\Projects\kalkulatorius\Debug\WHUU1.dll")]
            private static extern void addX(int x);
            [DllImport(@"C:\Visual Studio 2010\Projects\kalkulatorius\Debug\WHUU1.dll")]
            private static extern void addY(int y);
            [DllImport(@"C:\\Visual Studio 2010\Projects\kalkulatorius\Debug\WHUU1.dll")]
            private static extern void TestCallback(); 
            private int Handler(int text) 
            {
              textBox3.Text = text.ToString();
              return 42;                       
            }
         
        
            private void button1_Click(object sender, System.EventArgs e)
            {
              mInstance = new Callback(Handler); // to set the callback in lib 
              SetCallback(mInstance);            // could also be withhin constructor!
              addX(int.Parse(textBox1.Text)); // other people in this thread posted this correct answer
              addY(int.Parse(textBox2.Text));
              TestCallback();
            }
            public Form1()
            {
              InitializeComponent();
            }
