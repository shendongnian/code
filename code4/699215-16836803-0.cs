            private void MakeButton()
            {
             search_category s1 = new search_category();
            
                s1.id = m_id.Text;
                s1.name = m_name.Text;
                s1.l_name = m_l_name.Text; 
                s1.main_cat = d_d_main.SelectedValue;
                s1.second_cat = d_d_second.SelectedValue;
                s1.working_area = working_area.SelectedValue;
            
            
                List<member> m_list = db.return_search_member(s1);
            
                Table m_tbl = new Table();
                TableRow r2 = new TableRow();
            
                TableCell c7 = new TableCell();
                TableCell c8 = new TableCell();
                TableCell c9 = new TableCell();
                TableCell c10 = new TableCell();
                TableCell c11 = new TableCell();
                TableCell c12 = new TableCell();
            
                c7.Text = "תז";
                c8.Text="שם פרטי";
                c9.Text="שם משפחה";
                c10.Text="סיווג ראשי";
                c11.Text="סיווג משני";
            
                r2.Controls.Add(c12);
                r2.Controls.Add(c11); 
                r2.Controls.Add(c10);
                r2.Controls.Add(c9);
                r2.Controls.Add(c8);
                r2.Controls.Add(c7);
                r2.CssClass = " head_line";
            
            
                m_tbl.Controls.Add(r2);
            
            
                foreach (member m1 in m_list)
                {
            
                    TableRow r1 = new TableRow();
                    TableCell c1 = new TableCell();
                    TableCell c2 = new TableCell();
                    TableCell c3 = new TableCell();
                    TableCell c4 = new TableCell();
                    TableCell c5 = new TableCell();
                    TableCell c6 = new TableCell();
            
                    Button btn1 = new Button { Text = "עבור לכרטיס חבר", CommandArgument = "argument", ID = m1.id };
                    btn1.Click += new EventHandler(btn_click);
                    btn1.CssClass = "btn btn-primary";
                    c1.Controls.Add(btn1);
            
                    c2.Text = m1.prof.secondary;
                    c3.Text = m1.prof.primary;
                    c4.Text = m1.l_name;
                    c5.Text = m1.f_name;
                    c6.Text = m1.id;
            
                    r1.Controls.Add(c1);
                    r1.Controls.Add(c2);
                    r1.Controls.Add(c3);
                    r1.Controls.Add(c4);
                    r1.Controls.Add(c5);
                    r1.Controls.Add(c6);
            
                    m_tbl.Controls.Add(r1);
            
                }
             search_tbl_ph.Controls.Add(m_tbl);
            }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(ViewState["ClickEventFired"]!=null && ViewState["ClickEventFired"]==true)
            {
               MakeButton();
            }
        }
        protected void search_Click(object sender, EventArgs e)
        {
            MakeButton();
            ViewState["ClickEventFired"]=true;
        }
        protected void btn_click(object sender, EventArgs e)
        {
            // your code
        }
    
