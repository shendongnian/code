       public string ConvertDate(object pobjDate, string pstrDateFormat)
            {
                if (pobjDate == null || String.IsNullOrWhiteSpace(pobjDate.ToString()))
                    return String.Empty;
                else
                    return Convert.ToDateTime(pobjDate).ToString(pstrDateFormat);
            }
