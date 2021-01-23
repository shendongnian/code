    class Form1: Form
    {
        public void Button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.SomeMethodCalled += Form2_SomeMethodCalled;
        }
        public void Form2_SomeMethodCalled(object sender, EventArgs e)
        {
            // method in form2 called
        }
    }
    
    
    class Form2 : Form
    {
        public event EventHandler SomeMethodCalled;
    
        public void SomeMethod()
        {
            OnSomeMethodCalled();
            // .....
        }
    
        private void OnSomeMethodCalled()
        {
            var s = SomeMethodCalled;
            if(s != null)
            {
                s(this, EventArgs.Empty);
            }
        }
    }
