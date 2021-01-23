    [WebMethod]
    public static string GetReportDetails()
    {
        var reportDetails = DataAccess.Database().GetBusinessInterestReportDetails(HttpContext.Current.User.Identity.Name);
        return reportDetails;
    }
