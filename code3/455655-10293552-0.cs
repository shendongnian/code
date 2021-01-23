            var txtNewNameTb = (TextBox)GridAllStore.FooterRow.FindControl("txtNewName");
            var txtNewContactTb = (TextBox)GridAllStore.FooterRow.FindControl("txtNewContact");
            var txtNewAddressTb = (TextBox)GridAllStore.FooterRow.FindControl("txtNewAddress");
            var txtNewName = txtNewNameTb ? txtNewNameTb.Text: string.Embty; 
            var txtNewContact = txtNewContactTb ? txtNewContactTb.Text: string.Embty;
            var txtNewAddress = txtNewAddressTb ? txtNewAddressTb.Text: string.Embty;
            tastore.Insert(txtNewName, txtNewContact, txtNewAddress);    
            FillGrid();          
 
