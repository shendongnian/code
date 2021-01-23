    DateTime? dt = null;
            int pYear = 2012; // assuming pYear is getting populated from somewhere
            int finalYear = 1900; // initilizing some value to it;
            if (!(dt.HasValue))
                dt = DateTime.Now;
            var year = dt.Value.Year;
            var pValue = "1-Apr";
            if (pYear > year)
                finalYear = pYear - 1;
            else
            {
                finalYear = year;
            }
            return pValue + finalYear.ToString();
