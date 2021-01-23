      private void button1_Click(object sender, EventArgs e)
      {
         StartButton.IsEnabled = false;
         CancelButton.IsEnabled = true;
         Thread bg = new Thread(new ThreadStart( UpdateDatabase()));
         bg.Start();
      }
