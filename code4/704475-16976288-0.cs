    /* Spawned from a button click
    ...
    */
            string[] files = 
                Directory.GetFiles( 
                @"yourDicectory");
                foreach (string file in files)
                {
                    StreamReader fileReader = new StreamReader( file );
                    string lines = fileReader.ReadToEnd();
                    string[] entries = lines.Split( ',' );
                    // 
                    // Here I declare variables of types to insert "holders" 
                    //
                    SqlCeConnection con = new SqlCeConnection( "Data Source = Wages.sdf" );
                    con.Open();
                    SqlCeCommand cmd  = con.CreateCommand();
                    
                    //
                    // The insert command that takes the parsed values dt, me, ...
                    //
                    cmd.CommandText = "INSERT INTO Shifts ([Date], [T1], [T2], [T3]) VALUES (dt, me, mc, hp, gross, tax, net)";
                    //
                    // Here I parse and convert the values and store them in the holders
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
