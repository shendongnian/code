    using System.DirectoryServices;
    DirectoryEntry entry = new DirectoryEntry("LDAP://DC=DOMAIN, DC=local");
    DirectorySearcher mySearcher = new DirectorySearcher(entry);
    mySearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
    // define the properties you want
    mySearcher.PropertiesToLoad.Add("GivenName");
    mySearcher.PropertiesToLoad.Add("samAccountName");
    mySearcher.PropertiesToLoad.Add("sn");
    
    foreach (SearchResult resEnt in mySearcher.FindAll())
    {
       try
       {
           string givenName = "";
           string samAccountName = "";
           string surName = "";
           if(resEnt.Properties["GivenName"] != null && 
              resEnt.Properties["GivenName"].Count > 0) 
           {
               givenName = resEnt.Properties["GivenName"].Value;
           }
           if(resEnt.Properties["samAccountName"] != null && 
              resEnt.Properties["samAccountName"].Count > 0) 
           {
               samAccountName = resEnt.Properties["samAccountName"].Value;
           }
           if(resEnt.Properties["sn"] != null && 
              resEnt.Properties["sn"].Count > 0) 
           {
               surName = resEnt.Properties["sn"].Value;
           }
           comboBox2.Items.Add(givenName + " " + surName + " " + "[" + samAccountName + "]");
       }
       catch (Exception e)
       {
           // MessageBox.Show(e.ToString());
       }
    }
