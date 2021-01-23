    // These are the same
    ViewData["Title"] = "My new title";
    ViewBag.Title     = "My new title";
    // These are the same
    <%= ViewData["Title"] %>
    <%= ViewBag.Title %>
    public Dictionary<string, object> ViewData
    public dynamic ViewBag // .NET 4.0 +
