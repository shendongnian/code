            var linkDetails = new Dictionary<string, string>()
                {
                    {"NewCardGeneration.aspx", "Card Request"},
                    {"cardIssueAuth.aspx", "Card Issue"},
                    //.. and so on
                };
            //filter linkDetails depending on the DataTable
            IEnumerable<KeyValuePair<string, string>> filteredLinks = linkDetails.Where(kv => !DataTable.Contains(kv.Key));
