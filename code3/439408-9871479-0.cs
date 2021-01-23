     public static string BuildHTML()
    {
      int Currentpage = 4;
      int PageCount = 10;
      int ListCount = 5;
      int ListPerPage = 2;
      string html = string.Empty;
      if (ListCount > ListPerPage)
      {
        html += "<ul class=\"productListPaging\">";
        for (int x = 1; x <= PageCount; x++)
        {
          if (x == Currentpage)
          {
            html += "<li class=\"active\">";
          }
          else
          {
            html += "<li>";
          }
          html += "<a href=\"javascript:void(0);\" onclick=\"changePage(" + x + ");\">";
          html += x;
          html += "</a>&nbsp;";
          html += "</li> &nbsp;";
        }
        html += "</ul>";
      }
      return html;
    }
