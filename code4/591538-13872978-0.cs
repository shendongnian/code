    SomeMethod()
    {
        Using(...) 
        {
            Conn.open...
            Foreach (Company...)
            {
               ...GenerateWarnings(conn)..
            }
            Conn.close...
        }
    }
    GenerateWarnings(conn)
    {
        ...use conn to make db calls...
    }
