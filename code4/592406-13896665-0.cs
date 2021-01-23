    public class Form1 : Form
    {
        public void SomeMethod()
        {
            Player Player1 = new Player(this);
        }
    }
    public class Player()
    {
        public Player(Form form)
        {
            Textbox tb = new Textbox();
            form.Controls.Add(tb);
        }
    }
