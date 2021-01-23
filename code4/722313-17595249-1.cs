    //Create an SQL connection
    SqlConnection myConnection = new SqlConnection("MyConnString");
            
    //Open the connection
    try
    {
        myConnection.Open();
    }
    catch (Exception ex)
    {
        //Manually log the exception in ELMAH
        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        //Redirect the user to the error page
        response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message + "&ErrorType=SQLException", true);
    }
    return myConnection;
