                using (SqlConnection con = new SqlConnection("Data Source = [HostName]; Initial Catalog = CustomerOrders; Integrated Security = true"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name FROM Customer", con);
                    con.Open();
                    dropDownList.DataSource = cmd.ExecuteReader();
                    dropDownList.DataTextField = "Name";
                    dropDownList.DataValueField = "Name";
                    dropDownList.DataBind();
                }
