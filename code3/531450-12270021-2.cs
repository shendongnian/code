    void code_blue_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var checkBoxIds = GetCheckBoxIds();
        cust_modem = cust_modem_text.Text;
        trouble_shooting = tshooting_text.Text;
        services_offered = services_offered_text.Text;
        other_notes = other_notes_text.Text;
        //take off underscore convetion and replace with camelCase convention.
        CodeBlueForm cbForm = new CodeBlueForm(checkBoxIds, cust_name_text.Text, 
                                               cust_callback_text.Text, 
                                               cust_btn_text.Text,
                                               cust_modem + "\r\n" + 
                                               trouble_shooting + "\r\n" + 
                                               services_offered + "\r\n" + 
                                               other_notes);
        cbForm.Show();
    }
    private List<int> GetCheckBoxIds()//even better naming required like GetFruitIds() 
    {                                 //(whatever the id is of) or even better Tag  
                                      //checkBoxes with the Fruit object iself and not ids.
        List<int> checkBoxIds = new List<int>(); //So you can call GetFruits();
        foreach (Control control in pnlCheckBoxes.Controls)
        {
            if (control is CheckBox)
            {
                CheckBox checkBox = (CheckBox)control;
                if (checkBox.Checked && checkBox.Tag is int) //tag them as ints. 
                    checkBoxIds.Add((int)checkBox.Tag);      //I hope ids are integers.
            }
        }
        return checkBoxIds;
    }
    public partial class CodeBlueForm : Form
    {
        List<int> checkBoxIds = new List<int>():
        string cust_cbr_cb; //should be private.
        string cust_name_cb;
        string cust_wtn_cb;
        string cust_notes_cb;
        string cust_modem_cb;
    
        public CodeBlueForm(List<int> ids, string cust_name_cb, string cust_wtn_cb, 
                            string cust_notes_cb, string cust_modem_cb)
        {
            InitializeComponent();
            
            this.checkBoxIds = ids;
            this.cust_name_cb = cust_name_cb;
            this.cust_wtn_cb = cust_wtn_cb;
            this.cust_notes_cb = cust_notes_cb;
            this.cust_modem_cb = cust_modem_cb;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            cb_name_text.Text = cust_name_cb; 
            cb_wtn_text.Text = cust_wtn_cb;
            cb_cbr_text.Text = cust_cbr_cb;
            cb_notes_text.Text = cust_notes_cb;
    
            string checkBoxesLine = "\u2022 LIGHTS ";
            foreach (int id in ids)
                checkBoxesLine += string.Format("{0}, ", id); //or whatever that is.
    
            //and do what u want with checkboxline here.
        }
    }
