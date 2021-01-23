    string errMsg = string.Empty;
                    Boolean IsFromDateValid = false;
                    DateTime fromDate = new DateTime();
                    IsFromDateValid = ValidateDate(wdpfrom.Text.Trim(), "dd/MM/yyyy", ref errMsg, ref fromDate);
                    if (IsFromDateValid == false)
                    {
                        ShowMessage(errMsg);
                        return;
                    }
                    Boolean IsToDateValid = false;
                    DateTime toDate = new DateTime();
                    IsToDateValid = ValidateDate(wdpTo.Text.Trim(), "dd/MM/yyyy", ref errMsg, ref toDate);
                    if (IsToDateValid == false)
                    {
                        ShowMessage(errMsg);
                        return;
                    }
                    else
                    {
                        TimeSpan ts = new TimeSpan(23, 59, 59);
                        toDate = toDate.Add(ts);
                    }
