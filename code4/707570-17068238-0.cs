    private void Add_Color_Click(object sender, EventArgs e)
    {
        Form2 f2 = new Form2(this);
        f2.Show();
    }
    class Form2
    {
        private Form1 _frm;
        public Form2(Form1 frm)
        {
            //initialize + other code if required
            _frm = frm;
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            _frm.CreatePanel(/*param you need*/);  //name it what ever you want
        }
    }
