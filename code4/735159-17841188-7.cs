    private void ValidateEmailAddress(IEnumerable<CSVViewModel> csvData)
    {
        var invalidRows = csvData.Where(d => ValidEmail(d.EmailAddress) == false).ToList();
        foreach (var invalidRow in invalidRows)
        {
            var key = string.Format("csvData[{0}].{1}", invalidRow.RowNumber - 2, "EmailAddress");
            ModelState.AddModelError(key, "Invalid Email Address"); 
        }        
    }
    private static bool ValidEmail(string email)
    {
        if(email == "")
            return false;
        else
            return new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(email);
    }
