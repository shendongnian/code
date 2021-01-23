    public class Simple : Form
    {
        //now this is field is accessible from any method of declared within this class
        private TextBox _txt;
        public Simple()
        {
            Text = "Server Command Line";
            Size = new Size(800, 400);
            CenterToScreen();
            Button button = new Button();
            _txt = new TextBox ();
            _txt.Location = new Point (20, Size.Height - 70);
            _txt.Size = new Size (600, 30);
            _txt.Parent = this;
            _txt.KeyDown += submit;
            button.Text = "SEND";
            button.Size = new Size (50, 20);
            button.Location = new Point(620, Size.Height-70);
            button.Parent = this;
            button.Click += new EventHandler(sSubmit);   
    }
    private void submit(object sender, KeyEventArgs e)
    {
       if (e.KeyCode == Keys.Enter ) {
            Console.WriteLine (_txt.Text);//How do I grab this?
            Submit ();
        }
    }
}
