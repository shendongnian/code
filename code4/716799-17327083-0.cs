       public string _parameter;
       public Form1()
        {
            InitializeComponent();
             
         }
        public void form2_show_click(object sender, EventArgs e)
        {
           form2 frm = new form2();
           frm.ShowDialog();
            _parameter = frm.parameter;
         }
        
      form2
       public string parameter;
       public void form1_show_click(object sender, EventArgs e)
        {
           parameter = textBox1.Text;
           this.DialogResult = System.Windows.Forms.DialogResult.OK;
         }
