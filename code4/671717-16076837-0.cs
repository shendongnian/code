    class Form2
    {
        private Form1 _form1;
        public Form2()
        {
            // ...
        }
        public Form2(Form1 form1):this()
        {
            _form1 = form1;
        }
        void Button_Click(object sender, EventArgs e)
        {
            if(_form1 != null)
            {
                _form1.AddValue(textBox1.Text);
            }
        }
    }
