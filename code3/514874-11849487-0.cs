        using (SPSite Site = new SPSite(SPContext.Current.Site.Url + "/UberWiki"))
                            {
                                using (SPWeb currentWeb = Site.OpenWeb())
                                {
            
                                    SPList list = currentWeb.Lists["Pages"];
                                    SPFieldChoice field = (SPFieldChoice)list.Fields["Categories"];
            
                                    treeView = new System.Web.UI.WebControls.TreeView();
            
                                    foreach (string str in field.Choices)
                                    {
            
                                        treeNode = new System.Web.UI.WebControls.TreeNode(str);
            
                                        foreach (SPListItem rows in list.Items)
                                        {
                                            SPFieldMultiChoiceValue multiChoice = new SPFieldMultiChoiceValue(Convert.ToString(rows["Wiki Categories"]));
            
                                            string input = multiChoice.ToString();
    //remove the ;# that comes with the multiple choiches
                                            string cleanString = input.Replace(";#", "");
            
                                            if (cleanString == str)
                                            {
                                                string PageNameWithExt = rows.Name;
                                                
                                                childNode = new System.Web.UI.WebControls.TreeNode(PageNameWithExt);
                                       
                                                treeNode.ChildNodes.Add(childNode);
                                            }
                                        }
                                        treeView.Nodes.Add(treeNode);
                                    }
                                }
                            }
                            this.Controls.Add(treeView);
                            base.CreateChildControls();
                        }
