    /* Spawned from a button click
    ...
    */
            //
            // Here I bring in the directory which you'll likely replace with
            // a single file
            //
            string[] files = 
                Directory.GetFiles( 
                @"yourDicectory");
                
                // 
                // At this point you may disregard my loop if needed
                //
                foreach (string file in files)
                {
                    //
                    // Here the entire files are read and split
                    // Handle your data how you like
                    //  
                    StreamReader fileReader = new StreamReader( file );
                    string lines = fileReader.ReadToEnd();
                    string[] entries = lines.Split( ',' );
                    // 
                    // Here, omitted, I declare variables of types to insert "holders" 
                    // Every CSV has to go to a corresponding holder of the 
                    // the appropriate type (i.e., DateTime, decimal(money), or yourType)
                    //
                    SqlCeConnection con = new SqlCeConnection( "Data Source = YourDataSource.sdf" );
                    con.Open();
                    SqlCeCommand cmd  = con.CreateCommand();
                    
                    //
                    // The insert command that takes the parsed values dt, me, ...
                    // which are the named and omitted declarations from above
                    // You're providing a signature of the table you're inserting into
                    // 
                    cmd.CommandText = "INSERT INTO YourTable ([Column1], [Column2], [Column3], ... , [Column(n)]) VALUES (value1, value2, value3, ... , value(n))";
                    //
                    // Here, omitted, I parse and convert the values and store them in the holders
                    //
                    // Now execute and catch if needed
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch( SqlCeException sqle )
                        {
                            myTextbox.Text += sqle.Errors.ToString() + "\n";
                        }
                    }
                    //
                    // Update my view - May not apply
                    //
                    myGridView1.Update();
                    con.Close();
                }
        }
    }
