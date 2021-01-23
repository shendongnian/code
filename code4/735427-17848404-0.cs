    if (Session["[Indirizzo E-Mail]"] != null &&
        !string.IsNullOrEmpty(Session["[Indirizzo E-Mail]"].ToString()) &&
        !string.IsNullOrEmpty(TextBox2.Text))
    {
        string vem = Session["[Indirizzo E-Mail]"].ToString(); 
        using (var con = new SqlConnection(strcon))
        using (var ncmd = new SqlCommand("Update Utenti Set Nome = @vnome where [Indirizzo E-Mail]=@vem", con))
        {
            con.Open();
            ncmd.Parameters.AddWithValue("@vem", vem);
            ncmd.Parameters.AddWithValue("@vnome", TextBox2.Text);
            ncmd.ExecuteNonQuery();
        }
    }
    Label2.Text = "Dati aggiornati con successo!";
    Response.Redirect("~/ModificaDati.aspx");
