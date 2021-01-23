       private void MainForm_Load(object sender, EventArgs e) {
         ...
         // Assigning on click event, assuming that all your buttons are on the MainForm
         foreach (Control ctrl in Controls) {
            Button btn = ctrl as Button;
    
            if (!Object.ReferenceEquals(null, btn))
              btn.Click += onButtonClick;
         }
       ...
    
       // On click itself
       private void onButtonClick(Object sender, EventArgs e) {
         Button btn = sender as Button;
    
         String name = btn.Name; // <- Or whichever property of the button you want
       }
