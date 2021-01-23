    protected void pt_OnChange(object sender, EventArgs e)
    {
        idiom = "pt";
        Idioma.MudaCultura(idiom);
        GridView1.Columns[0].HeaderText = Idioma.RetornaMensagem("idTickets");
        GridView1.Columns[1].HeaderText = Idioma.RetornaMensagem("UserName");
        GridView1.Columns[2].HeaderText = Idioma.RetornaMensagem("AccessGroup");
        GridView1.Columns[3].HeaderText = Idioma.RetornaMensagem("FolderAccess");
        GridView1.Columns[4].HeaderText = Idioma.RetornaMensagem("RequestDate");
        GridView1.Columns[5].HeaderText = Idioma.RetornaMensagem("SituationDesc");
        GridView1.Columns[6].HeaderText = Idioma.RetornaMensagem("Approver");
        GridView1.Columns[7].HeaderText = Idioma.RetornaMensagem("ApprovalDate");
        GridView1.Columns[8].HeaderText = Idioma.RetornaMensagem("BusinessJustification");
        GridView1.Columns[9].HeaderText = Idioma.RetornaMensagem("Server");
        GridView1.Columns[10].HeaderText = Idioma.RetornaMensagem("UserRequestor");
        var listaTickets = new Tickets().ConsultarTickets();
        if (listaTickets != null)
        {
            this.GridView1.DataSource = listaTickets;
            if (listaTickets.Count != 0)
            {
                this.GridView1.DataBind();
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
