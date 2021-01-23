    class Contact
    {
        string FirstName;
        string LastName;
    }
    String greeting = "Mr. {FirstName} {LastName}, Welcome to the site ...";
    String result = greeting.Inject(new Contact
    {
        FirstName = "Brad",
        LastName = "Christie"
    });
