    public Student(string FirstName, string LastName, double Grade)
        : base(FirstName, LastName)
        {
         if(Grade >= 2.0 || Grade <= 6.00)
          throw  new ArgumentException("your message");     
        }
