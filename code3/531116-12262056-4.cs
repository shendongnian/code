    private void button1_Click(object sender, EventArgs e)
    {
      var tasks = new List<Task>();
      if (Text == "A")
      {
        tasks.Add(funcA());
      }
      if (Text == "B")
      {
        tasks.Add(funcB());
      }
      //And so on....
      Task.WhenAll(tasks.ToArray()).ContinueWith(t =>
      {
        MessageBox.Show("All done");
      });
    }
