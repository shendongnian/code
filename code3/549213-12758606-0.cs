    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private List<RadioButton> allMyButtons;
            public Form1()
            {
                InitializeComponent();
                allMyButtons = new List<RadioButton>
                {
                    radioButton1,
                    radioButton2
                };
            }
            private void radioButton_CheckedChanged(object sender, EventArgs e)
            {
                RadioButton sendingRadio = (sender as RadioButton);
                if(sendingRadio == null) return;
                if(sendingRadio.Checked == true){
                    foreach(var rb in (from b in allMyButtons where b != sendingRadio select b))
                    {
                        rb.Checked = false;
                    }
                }
            }
        }
    }
