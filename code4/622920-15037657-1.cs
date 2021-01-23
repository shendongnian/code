    var date = DateTime.Now.AddMonths(3);
    var dateString = date.Year.ToString() + date.Month.ToString().PadLeft(2, '0') +     date.Day.ToString().PadLeft(2, '0');
    var newsList = Sitecore.Context.Database.SelectItems("fast:/sitecore/content/home/your-path-to-news/*[@@templatename='Your template name' and @POSTED_DATE > '" + dateString + "']").ToList();
    newsList = newsList.OrderByDescending(n => n.Fields["POSTED_DATE"].Value).Take(2).ToList();
    newsContainer.DataSource = newsList;
    newsContainer.DataBind();
