    using NHibernate.Linq;
    public ISession DbSession { get; set; } // set on each Beginrequest with ISessionFactory.OpenSession();
    protected void Button1_Click(object sender, EventArgs e)
    {
        var registrations = DbSession.Query<Registration>()
            .Where(registration => registration.Name == txt_name.Text)
            .ToList();
        
        if (registrations.Count == 0 || registrations[0].Password != txt_pass.Text)
        {
            label4.Text ="Invalid Username/Password";
        }
        else
        {
            Session["new"] = txt_name.Text;
            Response.Redirect("logout.aspx");
        }
    }
