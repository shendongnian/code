     public Main()
        {
            InitializeComponent();
              Login p = new Login ();
             DialogResult dr =  p.ShowDialog();
             if(dr == DialogResult.OK)
              {
              }
              esle 
               Application.Exit();
         }
