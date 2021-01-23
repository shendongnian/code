    protected void ShowAll_Click(object sender, EventArgs e)
    {
      vertragsnehmer.DataSource = vertrag.Vertragsnehmer.Select(x=> new { x.Id, Name = x.GetFullName(), Typ = x.GetType().Name });
      vertragsnehmer.DataBind();
    
    }
