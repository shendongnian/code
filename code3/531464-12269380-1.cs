    protected void SetImageWidth()
    {
       try{
          Image1.Width = Convert.ToInt32(TextBox1.Text);
       }
       catch(System.FormatException)
       {
          Image1.Width = 100; // or other default value as appropriate in context.
       }
    }
