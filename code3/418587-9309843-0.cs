    DateTime birth = new DateTime(1950, 01, 01);
    DateTime diagnosis = new DateTime(2012, 02, 01);
    TimeSpan Span = diagnosis - birth;
    DateTime Age = DateTime.MinValue + Span;
    // note: MinValue is 1/1/1 so we have to subtract...
    int Years = Age.Year - 1;
