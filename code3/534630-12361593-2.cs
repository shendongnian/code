    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipalExtended userPrincipal = new UserPrincipalExtended(context);
    
        if (txtDisplayName.Text != "")
        {
            userPrincipal.DisplayName = "*" + txtDisplayName.Text + "*";
        }
        if (!string.IsNullOrEmpty(txtDepartment.Text.Trim())
        {
            userPrincipal.department = txtDepartment.Text.Trim();
        }
    
        using (PrincipalSearcher searcher = new PrincipalSearcher(userPrincipal))
        {
            foreach (Principal result in searcher.FindAll())
            {
               UserPrincipalExtended upe = result as UserPrincipalExtended;
               if (upe != null)
               {
                   DataRow drName = dtProfile.NewRow();
                   drName["displayName"] = upe.DisplayName;
                   drName["department"] = upe.department;
                   dtProfile.Rows.Add(drName);
               }
            }
        }
    } 
