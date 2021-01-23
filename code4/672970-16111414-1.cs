    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Form1 form;
        public Form1 OtherFrom
        {
            get { return form; }
            set
            {
                this.form=value;
                this.form.PressLock += new Action(ReadFromForm1);
            }
        }
        public void ReadFromForm1()
        {
            // xml reading here
        }
    }
