        /// <summary>
      /// Builds the paging HTML.
      /// </summary>
      /// <param name="currentpage">The current selected page.</param>
      /// <param name="totalPages">The total pages for paging.</param>
      /// <param name="dotsApearanceCount">The dots apearance count. How many dots (.) you want</param>
      /// <param name="groupCount">The group count. Group that is build based on selected page</param>
      /// <returns></returns>
      public string BuildPagingHTML(int currentpage, int totalPages, int dotsApearanceCount, int groupCount)
      {
        StringBuilder sbPagingHtml = new StringBuilder();
        sbPagingHtml.Append("<ul class=\"productListPaging\">");
        // Display the first page
        sbPagingHtml.Append("<li>");
        sbPagingHtml.Append("<a href=\"javascript:void(0);\" onclick=\"changePage(" + 1 + ");\">");
        sbPagingHtml.Append(1);
        sbPagingHtml.Append("</a>&nbsp;");
        sbPagingHtml.Append("</li> &nbsp;");
        if (totalPages > 1 && currentpage - 2 >= 1)
        {
          sbPagingHtml.Append(GenerateDots(dotsApearanceCount));
    
    
          for (var linkCount = currentpage - 2; linkCount <= currentpage + 2; linkCount++)
          {
            if (linkCount >= 2 && linkCount <= totalPages - 2)
            {
              if (currentpage == linkCount)
              {
                sbPagingHtml.Append("<li class='active'>");
              }
              else
              {
                sbPagingHtml.Append("<li>");
              }
    
              sbPagingHtml.Append("<a href=\"javascript:void(0);\" onclick=\"changePage(" + linkCount + ");\">");
              sbPagingHtml.Append(linkCount);
              sbPagingHtml.Append("</a>&nbsp;");
              sbPagingHtml.Append("</li> &nbsp;");
            }
          }
    
          sbPagingHtml.Append(GenerateDots(dotsApearanceCount));
    
          // Display the last page
          sbPagingHtml.Append("<li>");
          sbPagingHtml.Append("<a href=\"javascript:void(0);\" onclick=\"changePage(" + totalPages + ");\">");
          sbPagingHtml.Append(totalPages);
          sbPagingHtml.Append("</a>&nbsp;");
          sbPagingHtml.Append("</li> &nbsp;");
        }
    
        sbPagingHtml.Append("</ul>");
        return sbPagingHtml.ToString();
      }
    
      /// <summary>
      /// Generates the dots.
      /// </summary>
      /// <param name="numberofDots">The numberof dots.</param>
      /// <returns></returns>
      public string GenerateDots(int numberofDots)
      {
        StringBuilder sbPagingHtml = new StringBuilder();
        for (var dotCount = 1; dotCount <= numberofDots; dotCount++)
        {
          sbPagingHtml.Append("<li>");
          sbPagingHtml.Append("<a>");
          sbPagingHtml.Append(".");
          sbPagingHtml.Append("</a>&nbsp;");
          sbPagingHtml.Append("</li> &nbsp;");
        }
    
        return sbPagingHtml.ToString();
      }
