    //Clean Up Command Object
    if (mobj_SqlCommand != null)
    {
      mobj_SqlCommand.Dispose();
    }
    if (mobj_SqlConnection != null)
    {
      if (mobj_SqlConnection.State != ConnectionState.Closed)
      {
        mobj_SqlConnection.Close();
      }
      mobj_SqlConnection.Dispose();
    }
