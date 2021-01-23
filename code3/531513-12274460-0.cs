            string searchFilter = "(&(objectClass=user)(memberof=CN=Users,OU=t,OU=s,OU=x,DC=h,DC=nt))";
            string baseDN = "OU=C,OU=x,DC=h,DC=nt";
            var scope = SearchScope.Subtree;
            var attributeList = new string[] { "givenname", "sn", "samAccountName", "mail" };
            PageResultRequestControl pageSearchControl = new PageResultRequestControl(1000);
            do
            {
                SearchRequest sr = new SearchRequest(baseDN, searchFilter, scope, attributeList);
                sr.Controls.Add(pageSearchControl);
                var directoryResponse = ldapConnection.SendRequest(sr);
                if (directoryResponse.ResultCode != ResultCode.Success)
                {
                    // Handle error
                }
                var searchResponse = (SearchResponse)directoryResponse;
                pageSearchControl = null; // Reset!
                foreach (var control in searchResponse.Controls)
                {
                    if (control is PageResultResponseControl)
                    {
                        var prrc = (PageResultResponseControl)control;
                        if (prrc.Cookie.Length > 0)
                        {
                            pageSearchControl = new PageResultRequestControl(prrc.Cookie);
                        }
                    }
                }
                foreach (var entry in searchResponse.Entries)
                {
                    // Handle the search result entry
                }
            } while (pageSearchControl != null);
