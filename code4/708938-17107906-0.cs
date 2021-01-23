    for (int j = 0; j < db.UserDefinedFunctions.Count; j++)
            {
                UserDefinedFunction udf;
                udf = new UserDefinedFunction();
                udf = db.UserDefinedFunctions[j];
                if (!udf.IsSystemObject)// Exclude System User Defind Functions
                {
                    if (!udf.IsEncrypted) // Exclude already encrypted User Defind Functions
                    {
                        string text = "";// = sp.TextBody;
                        udf.TextMode = false;
                        udf.IsEncrypted = true;
                        udf.TextMode = true;
                        udf.Alter();
                        lblMsg.Text = udf.Name; // display name of the encrypted User Defind Functions.                        
                        udf = null;
                        text = null;
                    }
                }
            }
