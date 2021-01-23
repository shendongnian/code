    public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo,Func<int,string>pageUrl)
        {
            var result = new StringBuilder();
            var start = pagingInfo.CurrentPage > 1 ? pagingInfo.CurrentPage - 1:pagingInfo.CurrentPage;
            var end = start + pagingInfo.TotalDisplayPages;
            for (var i = start; i <= end; i++)
            {
                var tag = new TagBuilder("a");                
                // Construct an <a> tag
                tag.MergeAttribute("href", "");
                
                tag.InnerHtml = (i).ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.AppendLine(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
