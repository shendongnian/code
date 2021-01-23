    protected void btnPrasaj_Click(object sender, EventArgs e)
    {
        List<ListItem> lista = new List<ListItem>();
        string prasanje = null;
        Application.Lock();
        if (Application["prasanja"] == null) // za prvpat se postavuva prasanje
        {
            prasanje = txtNaslov.Text + "\n\n\n" + txtPrasanje.Text;
            lista.Add(new ListItem(prasanje, ddltema.SelectedIndex.ToString()));
            lstProblemPrasanje.DataSource = lista;
            //lstProblemPrasanje.DataTextField = "Text";
            //lstProblemPrasanje.DataValueField = "Value";
            lstProblemPrasanje.DataBind();
            Application["prasanja"] = lista;
        }
        else
        {
            lista=(List<ListItem>)Application["prasanja"];
            prasanje = txtNaslov.Text + "\n\n\n" + txtPrasanje.Text;
            lista.Add(new ListItem(prasanje, ddltema.SelectedIndex.ToString()));
            lstProblemPrasanje.DataSource = lista;
            //lstProblemPrasanje.DataTextField = "Text";
            //lstProblemPrasanje.DataValueField = "Value";
            lstProblemPrasanje.DataBind();
            Application["prasanja"] = lista;
        }
        Application.UnLock();
    }
