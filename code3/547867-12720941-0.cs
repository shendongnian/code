    Label lbl ;
    int count = 1;
                private void Page_Load(object sender, System.EventArgs e)
                {
                    Button btn = new Button();
                    btn.Text = "Click Me";
                    btn.Click  += btn_Click;
                    lbl = new Label();
                    form1.Controls.Add(btn);
                    form1.Controls.Add(lbl);
        
                    
                }
        
                protected void btn_Click(object sender, EventArgs e)
                {
                    count++;
                    lbl.Text = count.ToString();
                    
                }
