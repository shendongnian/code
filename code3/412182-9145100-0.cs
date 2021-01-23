    try
    {
       clientAD.Update(clientDS, "Client");
    }
    catch( Exception oError )
    {
       MessageBox.Show( oError.Message );
    }
