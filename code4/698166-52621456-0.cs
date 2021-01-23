     for (int i = 0; i < 7; i++){
         .
         .
         .
         string text = "some things...";
         this.addToDay[i] = new System.Windows.Forms.Button();
         this.addToDay[i].Click += (object sender, EventArgs e)=>
         {
            //you can use your variables inside event
            MessageBox.ShowDialog(text + i);
         };
     }
