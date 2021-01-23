    protected void verif(Object sender, EventArgs e)
    {
        if (Session["user"].Equals("magasinier"))
        {
            DialogResult result1 = MessageBox.Show("Non autorisé!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (result1 == DialogResult.OK)
            {
                result1 = DialogResult.Ignore;
            }
        }
        else
        { 
            Response.Redirect( ((System.Web.UI.HtmlControls.HtmlAnchor)sender).HRef);//sender your anchor tag --takes it href attribute and redirect
        }
    }
