    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Form2 frm2 = new Form2();
                frm2.RaiseCustomEvent+=new CustomEventHandler(frm2_RaiseCustomEvent);
                frm2.Show(this);
            }
            void frm2_RaiseCustomEvent(object sender, CustomEventArgs a)
            {
                textBox1.Text = a.Message;
            }
        }
    }
