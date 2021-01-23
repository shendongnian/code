            //...
            public Form()
            {
                InitializeComponent();
            }
    
            private void Form_Load(object sender, EventArgs e)
            {
                Console.SetOut(new TextBoxWriter(txtConsole));
                Console.WriteLine("Now redirecting output to the text box");
            }
