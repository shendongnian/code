    using( SqlConnection connection = new SqlConnection( this.GetConnectionString() ) )
    {
        //  Open Connection
        //  Access the database
        //  Close the connection <- Manual closing MAY not be needed as it might be done in Dispose ...check MSDN for clarification.
    }
