    public class Form1 : Form {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string msgName);
        public Form1(){
            InitializeComponent();
            red = RegisterColorCode(Color.Red);
            yellow = RegisterColorCode(Color.Yellow);
            //Set your form caption to a specified (must be unique at the time it runs)
            Text = "Winforms Application";
        }
        int red,yellow;//you can define more
        private int RegisterColorCode(Color c){
            return RegisterWindowMessage(c.ToString());
        }
        protected override void WndProc(ref Message m)
        {
            switch(m.Msg){
               case red:
                  yourButton.BackColor = Color.Red;
                  return;
               case yellow:
                  yourButton.BackColor = Color.Yellow;
                  return;
            }
            base.WndProc(ref m);
        }
    }
