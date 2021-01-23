    public Teacher( string name, Student student )
    {
      student.teacher = this;  //st.Teacher is assigned BEFORE exception raised.
      if ( name.Length < 5 )
        throw new ArgumentException( "Name must be at least 5 characters long." );
    }
