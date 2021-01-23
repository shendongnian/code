    if (!(tempCnic==1))
            {
                Session["nameFull"] = TextBoxFN.Text;
                Session["CNIC"] = TextBoxCNIC.Text;
                Response.Redirect("Error_InvalidCNIC.aspx");
        }
