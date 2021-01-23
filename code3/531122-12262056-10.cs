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
        if (t.Exception != null)
        {
          //One of the tasks threw an exception
          MessageBox.Show("There was an exception!");
        }
        else
        {
          //None of the tasks threw an exception
          MessageBox.Show("No Exceptions!");
        }
      });
    }
