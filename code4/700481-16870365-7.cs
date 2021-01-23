            var sections = new List<Section>()
                               {
                                   new Section()
                                       {
                                           Header = "Authorization",
                                           SubLinkDetails = new Dictionary<string, string>()
                                                            {
                                                                {"NewCardGeneration.aspx", "Card Request"},
                                                                {"cardIssueAuth.aspx", "Card Issue"},
                                                                //.. and so on
                                                            }
                                       }
                                   //.. other sections follow
                               };
            //filter subLinkDetails depending on the DataTable entries
            sections.ForEach(s => s.SubLinkDetails.RemoveWhere(k => DataTable.Contains(k)));
