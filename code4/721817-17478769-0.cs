    class MyForm1
    {
        public MyForm2 Form2 { get; set; }
        protected OnButton1Clicked()
        {
            Form2.ToggleButton();
        }
    }
    class MyForm2
    {
        public ToggleButton()
        {
            button2.Enabled = !button2.Enabled;
        }
    }
    // Main
    form1 = new MyForm1();
    form1.Form2 = new MyForm2();
