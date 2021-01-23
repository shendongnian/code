    private void myMethod(DataReceivedEventArgs e) {       
      if (e.Data != null) {
        Action action = () => rchstdOut.Text = e.Data.ToString();
        rchstdOut.Invoke(action, null);
        Console.WriteLine(e.Data.ToString());
      }
    }
