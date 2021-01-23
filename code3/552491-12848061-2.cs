        public Form1() // constructor
        {
            InitializeComponent(); // ensure all controls are created.
       
            List<Button> buttons = new List<Button>(30);
        
            buttons.Add(mybutton1)
            buttons.Add(mybutton2)
            // go futher with all your buttons.
          
        }
        private void Form1_Load(object sender, System.EventArgs e) // create a load event
        {    
           foreach(Button button in buttons)
           {
              button.BackgroundImage = Image.FromFile(path);
              // Note: The file remains locked until the Image is disposed!
           }
        }
       
