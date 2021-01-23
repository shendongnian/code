    try
    {
       // ...
       SqlCommand.ExecuteNonQuery( ... );
    }
    catch( Exception ex )
    {
       MessageBox.Show( ex.ToString( ) );
    }
