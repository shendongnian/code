    public partial class Form1 : Form
    {
        public static Form1Instance;
        ...
        Form1.OnLoad(...)
        {
            Form1Instance=this;
        }
    }
    //now call using static variable
    Form1.Form1Instance.CheckBox1_Checked=true;   
