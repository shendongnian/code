    protected void btn_OnClick(object sender, EventArgs e)
    {
        if(!String.IsNullOrWhiteSpace(tb.Text))
        {
            Class1 cl = new Class1();
            List<Complainer> complainers = cl.SearchBySurname(tb.Text);
            gv.DataSource = complainers;
            gv.DataBind();
        }
    }
