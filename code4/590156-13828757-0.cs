    }
    catch( IOException e )
    {
       MessageBox.Show("There was an error saving this game: " + e.Message
                        , "ERROR"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation
                        , MessageBoxDefaultButton.Button1);
    }
