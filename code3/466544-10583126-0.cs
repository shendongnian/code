    class Person
    {
        [Required(ErrorMessage = "Please enter the FirstName of person")]
        string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the LastName of person")]
        string LastName { get; set; }
    }
    class Student : Person
    {
    }
