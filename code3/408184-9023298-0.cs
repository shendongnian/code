    if (string.IsNullOrEmpty(Request.Form["StartDate"]) == false)
        {
            var dtValue = new DateTime();
            if (DateTime.TryParse(Request.Form["StartDate"], out dtValue)) {
                _startDate = dtValue;
            }
            else {
                _startDate = null;
            }
        }
        else
        { _startDate = null; }
