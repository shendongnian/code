    interface ICustomPrincipal : IPrincipal
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
