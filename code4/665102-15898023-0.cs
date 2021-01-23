        private void button1_Click(object sender, EventArgs e)
        {
            c = new Class1(this);
            c.x();
        }
        class Class1
        {
            public static Form1 f;
            public Class1(Form1 form)
            {
                f = form;
            }
            public void x()
            {
                f.textBox1.Text = "hello";
            }
        }
