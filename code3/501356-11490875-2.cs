    while (Reader.Read())//it gives exception here
    //The err Operation is not valid due to the current state of the object.
                    {  
                        intCount =Convert.ToInt32(Reader[0]);
                        Reader.Close();
                        oraCommand.Connection.Close();
                        oraCommand = null;
                        if (intCount > 0)
                        {
                            return 1;
                        } 
                        // if intCOunt == 0 then what? loop again
                    }
