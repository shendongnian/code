        private void button1_Click(object sender, EventArgs e)
        {
            GetSomeTextForSomeReason();
        }
        private async void GetSomeTextForSomeReason()
        {
            var s = await Task.Factory.StartNew(() =>
                                      {
                                          for (int i = 0; i < 500000000; i++) ; // simulate a delay
                                          return "This is text";
                                      });
            textBox1.Text = s;
        }
