    protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                createcontrol();
            }
        }
    private void createcontrol()
        {
    
            for (int i = 0; i < 5; i++)
            {
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                HtmlGenericControl td = new HtmlGenericControl("td");
                HtmlGenericControl tdbtn = new HtmlGenericControl("td");
                TextBox txt = new TextBox();
                txt.ID = "txt_" + i.ToString();
                td.Controls.Add(txt);
                Button btn = new Button();
                btn.ID = "btn_" + i.ToString();
                btn.Click += new EventHandler(btnpay_Click);
                btn.Text = "Pay";
                tdbtn.Controls.Add(btn);
                tr.Controls.Add(td);
                tr.Controls.Add(tdbtn);
                plh1.Controls.Add(tr);
            }
        }
    protected void btnpay_Click(object sender, EventArgs e)
        {
    
            Button btn = new Button();
            btn = sender as Button;
            string[] splitvaues = btn.ID.Split('_');
            string identity = splitvaues[1].ToString();
            TextBox txt = new TextBox();
            txt = plh1.FindControl("txt_" + identity) as TextBox;
            string q = txt.Text;
    
        }
     protected void Button1_Click(object sender, EventArgs e)
        {
            createcontrol();
    }
