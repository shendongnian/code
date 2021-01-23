    public class Simple : Form
    {
      public Simple()
      {
        Text = "Server Command Line";
        Size = new Size(800, 400);
        CenterToScreen();
        Button button = new Button();
        txt = new TextBox ();
        txt.Location = new Point (20, Size.Height - 70);
        txt.Size = new Size (600, 30);
        txt.Parent = this;
        txt.KeyDown += submit;
        button.Text = "SEND";
        button.Size = new Size (50, 20);
        button.Location = new Point(620, Size.Height-70);
        button.Parent = this;
        button.Click += new EventHandler(sSubmit);   
      }
      TextBox txt;
      private void submit(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter ) {
            Console.WriteLine (txt.Text);
            Submit();
         }
      }
    }
