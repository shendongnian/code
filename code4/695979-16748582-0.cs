    public partial class Form2 : Form
    {
        private Form1 form;
    
        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }
    
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            form.Opacity = trackBar1.Value * 000.1d;
        }
      }
    }
