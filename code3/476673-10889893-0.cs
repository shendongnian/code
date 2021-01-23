                using (SPSite mySite = new SPSite("http://server"))
                {
                    //open the relevant site
                    using (SPWeb myWeb = mySite.OpenWeb("TestSite"))
                    {
                        //loop through the lists
                        foreach (SPList list in myWeb.Lists)
                        {
                            //when we find the correct list, change the name
                            if (list.RootFolder.Name == "OrigListName")
                            {
                                //move the root folder
                                list.RootFolder.MoveTo(list.RootFolder.Url.Replace("OrigListName", "OrigListName_New"));
                            }
                        }
                    }
                }
