    public class ReviewRepo : BaseRepo
    {
        public ReviewRepo(string connectionString) : base(connectionString) { }
        public ReviewPageableResult GetAllReviews(string productType, string serviceType, int pageNumber, int itemsPerPage, string sortBy, string sortDirection)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("ProductRefDescription", productType),
                new SqlParameter("ServiceRefDescription", serviceType),
                new SqlParameter("ZipCodes", "NULL"),
                new SqlParameter("PageNumber", pageNumber),
                new SqlParameter("ItemsPerPage", itemsPerPage),
                new SqlParameter("SortBy", sortBy),
                new SqlParameter("SortDirection", sortDirection)
            };
            var cmd = new SqlCommand("dbo.GetReviews");
            cmd.Parameters.AddRange(parameters.ToArray());
            var results = ExecuteSqlReader(CreateReview, CreateReviewPageableResult, cmd, commandType: CommandType.StoredProcedure);
            var reviewResult = results.Item2.Single();
            reviewResult.Items = results.Item1;
            return reviewResult;
        }
        public ReviewPageableResult GetReviewsByZip(string productType, string serviceType, string zipCodes, int pageNumber, int itemsPerPage, string sortBy, string sortDirection)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("ProductRefDescription", productType),
                new SqlParameter("ServiceRefDescription", serviceType),
                new SqlParameter("ZipCodes", zipCodes),
                new SqlParameter("PageNumber", pageNumber),
                new SqlParameter("ItemsPerPage", itemsPerPage),
                new SqlParameter("SortBy", sortBy),
                new SqlParameter("SortDirection", sortDirection)
            };
            var cmd = new SqlCommand("dbo.GetReviewsByZipCodes");
            cmd.Parameters.AddRange(parameters.ToArray());
            var results = ExecuteSqlReader(CreateReview, CreateReviewPageableResult, cmd, commandType: CommandType.StoredProcedure);
            var reviewResult = results.Item2.Single();
            reviewResult.Items = results.Item1;
            return reviewResult;
        }
        private Review CreateReview(IDataRecord record)
        {
            return new Review
            {
                PageReviewId = (int)record["PageReviewId"],
                ProductRefId = (Guid)record["ProductRefId"],
                ServiceTypeRefId = Convert.IsDBNull(record["ServiceTypeRefId"]) ? Guid.Empty : (Guid)record["ServiceTypeRefId"],
                TerritoryId = Convert.IsDBNull(record["TerritoryId"]) ? Guid.Empty : (Guid)record["TerritoryId"],
                FirstName = $"{record["FirstName"]}",
                LastName = $"{record["LastName"]}",
                City = $"{record["City"]}",
                State = $"{record["State"]}",
                Answer = $"{record["Answer"]}",
                Rating =(double)record["Rating"],
                SurveyDate = (DateTime)record["SurveyDate"]
            };
        }
        private ReviewPageableResult CreateReviewPageableResult(IDataRecord record)
        {
            return new ReviewPageableResult
            {
                AverageRating = (double)record["AverageRating"],
                Count1Stars = (int)record["Count1Stars"],
                Count2Stars = (int)record["Count2Stars"],
                Count3Stars = (int)record["Count3Stars"],
                Count4Stars = (int)record["Count4Stars"],
                Count5Stars = (int)record["Count5Stars"],
                ItemsPerPage = (int)record["ItemsPerPage"],
                PageNumber = (int)record["PageNumber"],
                TotalCount = (int)record["TotalCount"],
            };
        }
    }
