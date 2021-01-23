    Uri u = new Uri("https://localhost:8181/PortalSite/View/CommissionStatement.aspx?status=commission&quarter=1;");
    Console.WriteLine(u.Query); // Prints "status=commission&quarter=1;"
    // Reference System.Web.dll for HttpUtility
    var parameters = HttpUtility.ParseQueryString(u.Query);
    Console.WriteLine(parameters["status"]); // Prints "commission"
