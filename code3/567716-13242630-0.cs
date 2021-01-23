     foreach (DataRow row in dt.Rows)
                        {
                            try
                            {
                               
                                    string lname = row[0].ToString();
                                    string fname = row[1].ToString();
                                    string ss1 = row[2].ToString();
                                    long? s = ss1 == "" ? (long?)null : Convert.ToInt64(ssn1);
                                    string dob1 = row[3].ToString();
                                    string b = dob1 == "" ? null : dob1;
