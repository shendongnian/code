     private string selectedValue, date;
            private int i;
            private SqlCommand xcmd;
            private SqlConnection xcon;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    day_DropDownList.Items.Insert(0, new ListItem("DD", "DD"));
                    month_DropDownList.Items.Insert(0, new ListItem("MM", "MM"));
                    year_DropDownList.Items.Insert(0, new ListItem("YY", "YY"));
                    for (i = 1; i < 32; i++)
                    {
                        day_DropDownList.Items.Add(i.ToString());
                    }
                    for (i = 1; i < 13; i++)
                    {
                        month_DropDownList.Items.Add(i.ToString());
                    }
                    for (i = 1950; i < 2014; i++)
                    {
                        year_DropDownList.Items.Add(i.ToString());
                    }
                    employeeName_Txt.Focus();
                }
    
    
            }
    
    
    
            protected void submit_Button_Click(object sender, EventArgs e)
            {
                selectedValue = gender_RadioButtonList.SelectedValue;
    
                xcon = new SqlConnection("Data Source=.; DataBase=AptechDB; UID=sa; Password=123;");
    
                xcon.Open();
                date = day_DropDownList.Text.ToString() + "/" + month_DropDownList.Text.ToString() + "/" + year_DropDownList.Text.ToString();
                xcmd = new SqlCommand("insert into tblEmployee values('" + employeeName_Txt.Text + "','" + date + "','" + selectedValue + "','" + post_Txt.Text + "','" + city_Txt.Text + "','" + country_Txt.Text + "','" + mobileno_Txt.Text + "')", xcon);
                xcmd.ExecuteNonQuery();
                Label1.Text = "Information submitted successfully";
                xcon.Close();
                clear();
            }
    
            public void clear()
            {
                employeeName_Txt.Text = "";
                day_DropDownList.SelectedIndex = 0;
                month_DropDownList.SelectedIndex = 0;
                year_DropDownList.SelectedIndex = 0;
                post_Txt.Text = "";
                city_Txt.Text = "";
                country_Txt.Text = "";
                mobileno_Txt.Text = "";
            }
    
        }
    }
