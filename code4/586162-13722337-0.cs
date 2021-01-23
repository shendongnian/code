    public partial class Form1 : Form
    {    
        frmConfig f2;
        String SIp;
    
        public Form1(frmConfig Cont)
        {
            f2 = Cont;
            String SIp = f2.txtSrcIP.text;
        }
    }
