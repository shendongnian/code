    DateTime Birthday = new DateTime(1973, 7, 10);
    DateTime Today = DateTime.Now;
    TimeSpan Span = Today - Birthday;
    DateTime Age = DateTime.MinValue + Span;
    // MinValue is 1/1/1 so we have to subtract one year
    int Years = Age.Year - 1;
