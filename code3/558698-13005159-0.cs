    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table")) {
        ///This is the table.    
        foreach (HtmlNode row in table.SelectNodes("tr")) {
        ///This is the row.
            foreach (HtmlNode cell in row.SelectNodes("th|td")) {
                ///This the cell.
            }
        }
    }
