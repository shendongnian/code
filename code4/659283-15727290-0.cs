    public partial class Form1 : Form
    {
        //Other codes
        private void loadlogin()
        {
            login log = new login(this);    //CHANGE HERE
            mainPannel.Controls.Clear();
            mainPannel.Controls.Add(log);
        }
        //Other codes
    }
