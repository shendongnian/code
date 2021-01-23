    protected void Page_Load(object sender, EventArgs e)
            {
                var lstPerson = new List<Person>();
                lstPerson.Add(new Person { Name = "N1", Age = 20 });
                lstPerson.Add(new Person { Name = "N2", Age = 30 });
    
                Context.Items["WebForm1List"] = lstPerson;
    
                Server.Transfer("Page2.aspx");
    
            }
