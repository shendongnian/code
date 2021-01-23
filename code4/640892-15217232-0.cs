    protected void Page_Load(object sender, EventArgs e)
    {
        List<Person> lstPerson = new List<Person>();
        lstPerson.Add(new Person { Name = "N1", Age = 20 });
        lstPerson.Add(new Person { Name = "N2", Age = 30 });      
        Response.Redirect("Page2.aspx?Param=" + lstPerson);
        Session["listOfPersons"] = lstPerson;
    }
