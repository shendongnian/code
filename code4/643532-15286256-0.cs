    public DataTable Accountlocked()
            {
               //DirectoryEntry entry = new DirectoryEntry("LDAP://Mytechnet.com");
               DirectoryEntry entry = new DirectoryEntry("LDAP://User");
               DirectorySearcher Dsearch = new DirectorySearcher(entry);
    
               Dsearch.Filter = "(&(&(&(&(&(objectCategory=person)(objectClass=user)>>(lockoutTime:1.2.840.113556.1.4.804:=4294967295))))))";
    
               DataTable dt = new DataTable();
               dt.Columns.Add("AccountName");
               dt.Columns.Add("Name");
                    foreach (SearchResult sResultSet in Dsearch.FindAll())
                    {
                       DataRow dr = dt.NewRow();          
                       dr[0] = (GetProperty(sResultSet, "samaccountname"));
                       dr[1] = (GetProperty(sResultSet, "name"));
                       dt.Rows.Add(dr);
                    }
                    return dt;
                }
            }
    dataGridView1.DataSource = Accountlocked();
