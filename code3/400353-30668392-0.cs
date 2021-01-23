                        if (date.Length !=8)
                        {
                            return ConvertToDate("");
                        }
            int iYear; int.TryParse(date.Substring(0, 4), out iYear);
            int iMonth; int.TryParse(date.Substring(4, 2), out iMonth);
            int iDay; int.TryParse(date.Substring(6, 2), out iDay);
            return new DateTime(iYear, iMonth, iDay);
        }
