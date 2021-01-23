    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private CookieContainer cookies;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            public bool od_auth(string login, string pass)
            {
                cook­ies = new CookieContainer();
                request.CookieContainer = cookies;
    
                if (response.Headers["Location"] != null)
                {
                    return true;
                }
                else
                {
                    return false;
    
                }
            }
    
            public bool od_info_changer()
            {
                request.CookieContainer = cookies;
                if (response.Headers["Location"].IndexOf("st.cmd=userSettings") != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
    
            }
    
            private void Auth_Click(object sender, EventArgs e)
            {
                string login = textBox1.Text;
                string pass = textBox2.Text;
                bool avt = od_auth(login, pass);
                bool change = od_info_changer();
                if (avt == true)
                {
    
                }
                else
                {
                }
                if (change == true)
                {
                }
                else
                {
                }
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
        }
    }
