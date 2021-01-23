    protected void Page_Load(object sender, EventArgs e) {
                
        // A simple example using Page_Load
        List<Person> people = new List<Person>();
        for (int i = 0; i < 10; i++) {
            people.Add(new Person() {Name = "Test", Age = 10, BirthDate=DateTime.Now, LastName = "Test"});
        }
    
        if (!IsPostBack) {
            repPeople.DataSource = people;
            repPeople.DataBind();
        }
    
    }
