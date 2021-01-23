    try
        {
            _SqlConnection = new SqlConnection("server=.;user id=sa;password=sa;initial catalog=RealEstate");
            _SqlConnection.Open();
            _SqlCommand = new SqlCommand(query, _SqlConnection);
           _SqlDataReader  = _SqlCommand.ExecuteReader();
        }
        **catch (Exception sm)
        {
         _SqlDataReader = null;
        }**
