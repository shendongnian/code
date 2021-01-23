    var getContacts = (from r in gServiceContext.CreateQuery("account")
                               join c in gServiceContext.CreateQuery("contact") on ((EntityReference) r["accountid"]).Id
                                   equals c["accountid"]
                               where r["accountid"].Equals(ddlCustomer.SelectedValue)
                               select new
                                          {
                                              FirstName = !c.Contains("firstname") ? string.Empty : c["firstname"],
                                              LastName = !c.Contains("lastname") ? string.Empty : c["lastname"],
                                          }).ToList();
            if (getContacts.Count > 2)
            {
                ddlMultipleContacts.DataSource = getContacts;
                ddlMultipleContacts.DataTextField = "LastName";
                ddlMultipleContacts.DataValueField = "LastName";
                ddlMultipleContacts.DataBind();
            }
            else if (getContacts.Count == 1)
            {
                txtContact1Name.Text = contact.FirstName + " " + contact.LastName;
            }
            else if (getContacts.Count == 2)
            {
                txtContact1Name.Text = contact[0].FirstName + " " + contact[0].LastName;
                txtContact2Name.Text = contact[1].FirstName + " " + contact[1].LastName;
            }
        
