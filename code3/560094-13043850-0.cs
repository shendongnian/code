            FillSelect(myDropDownList, "--select--", "0", true);
            public static void FillSelect(DropDownList DropDown, string SelectItemText, string SelectItemValue, bool includeselectitem)
            {
                List<PhoneContact> obj_PhoneContactlist = getAll();
    
                if (obj_PhoneContactlist != null && obj_PhoneContactlist.Count > 0)
                {
                    DropDown.DataTextField = "PhoneContactName";
                    DropDown.DataValueField = "id";
                    DropDown.DataSource = obj_PhoneContactlist.OrderBy(o => o.PhoneContactName);//linq statement
                    DropDown.DataBind();
    
                    if (includeselectitem)
                        DropDown.Items.Insert(0, new ListItem(SelectItemText, SelectItemValue));
                }
            }
            public static List<PhoneContact> getAll()
            {
                
            obj_PhoneContactlist = new List<PhoneContact>();
            string QueryString;
            QueryString = System.Configuration.ConfigurationManager.ConnectionStrings["Admin_raghuConnectionString1"].ToString();
    
            obj_SqlConnection = new SqlConnection(QueryString);
    
            obj_SqlCommand = new SqlCommand("spS_GetMyContacts");
            obj_SqlCommand.CommandType = CommandType.StoredProcedure;
            obj_SqlConnection.Open();
            obj_SqlCommand.Connection = obj_SqlConnection;
            SqlDataReader obj_result = null;
            obj_SqlCommand.CommandText = "spS_GetMyContacts";
            obj_result = obj_SqlCommand.ExecuteReader();
    
    
            //here read the individual objects first and append them to the listobject so this we get all the rows in one list object
    
            using (obj_result)
            {
                while (obj_result.Read())
                {
                    obj_PhoneContact = new PhoneContact();
                    obj_PhoneContact.PhoneContactName = Convert.ToString(obj_result["PhoneContactName"]).TrimEnd();
                    obj_PhoneContact.PhoneContactNumber = Convert.ToInt64(obj_result["PhoneContactNumber"]);
                    obj_PhoneContact.id = Convert.ToInt64(obj_result["id"]);
                    
                    obj_PhoneContactlist.Add(obj_PhoneContact);
                }
    
            }
    
            return obj_PhoneContactlist;
            }
