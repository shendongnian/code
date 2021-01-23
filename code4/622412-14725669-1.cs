    public static class HtmlExtensions
    {
        public static IHtmlString MyHelper(this HtmlHelper<MyViewModel> html, string itemsToShow)
        {
            var sb = new StringBuilder();
            if (itemsToShow == "namepart")
            {
                sb.Append(html.DisplayFor(x => x.FirstName));
                sb.Append(html.DisplayFor(x => x.SecondName));
            }
            else
            {
                sb.Append(html.DisplayFor(x => x.DateOfBirth));
                sb.Append(html.DisplayFor(x => x.DateOfWorkStart));
                sb.Append(html.DisplayFor(x => x.NumberOfChildren));
            }
            return new HtmlString(sb.ToString());
        }
    }
