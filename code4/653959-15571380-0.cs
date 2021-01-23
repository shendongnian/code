    public partial class Form1: Form
    {
        Test _Test = new Test()
        public GrabGames()
        {
            InitializeComponent();
            _Test._TestMethod(this); //pass this form to the other form
        }
        public void _MainPublicMethod(string _Message, string _Text)
        {
            MessageBox.Show(Message);
            TextBox1.Text = Text;
        }
    }
    class Test
    {
       public void _TestMethod(Form1 owner)
       {
           //call the main public method on the calling/owner form
           owner._MainPublicMethod("Test Message", "Test Text");
       }
    }
