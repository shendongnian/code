    DateTime? closingDate;
    
    if (!string.IsNullOrEmpty(myClosingDateString))
    {
        closingDate = DateTime.Parse(myClosingDateString);
    }
    // do whatever else you need
 
    // when it comes time to appending ...
    if (!closingDate.HasValue) // or check if it's `DateTime.MinValue`
    {
        fileListHtml += "No closing date";
    }
    else
    {
        fileListHtml += closingDate.Value.ToString();
    }
