    public List<ResultsFTSDTO> getAdvancedFTSResults(
                string searchText, int minRank,
                bool IncludeTitle,
                bool IncludeDescription,
                int StartYear,
                int EndYear,
                string FilterTags) {
            AdvancedFTS sp = new AdvancedFTS() {
                SearchText = searchText,
                MinRank = minRank,
                IncludeTitle=IncludeTitle,
                IncludeDescription=IncludeDescription,
                StartYear=StartYear,
                EndYear = EndYear,
                FilterTags=FilterTags
            };
            IEnumerable<ResultsFTSDTO> resultSet = _context.Database.ExecuteStoredProcedure(sp, "ResultsAdvancedFTS");
            return resultSet.ToList();
        }
