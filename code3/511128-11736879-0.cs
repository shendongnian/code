    protected void btnPrasaj_Click(object sender, EventArgs e)
    {
        string key = "prasanja";
        List<ListItem> lista = new List<ListItem>();
        string prasanje = null;
        Application.Lock();
        if (Application[key] != null) // za prvpat se postavuva prasanje
        {
            lista = (List<ListItem>)Application[key];
        }
        prasanje = txtNaslov.Text + "\n\n\n" + txtPrasanje.Text;
        lista.Add(new ListItem(prasanje, ddltema.SelectedIndex.ToString()));
        lstProblemPrasanje.DataSource = lista;
        lstProblemPrasanje.DataBind();
        Application[key] = lista;
        Application.UnLock();
    }
