    string getArrivalDate   = ArrivalDate;
                        string getDepartureDate = DepartureDate;
    
                        string dteFormat        = "dd/MM/yyyy";
                        DateTime result;
                        string arrivalDateParse;
                        string departureDateParse;
    
                        bool arrival = DateTime.TryParseExact(getArrivalDate, dteFormat, new CultureInfo("en-GB"), DateTimeStyles.None, out result);
                        if (arrival)
                            {
                            arrivalDateParse = getArrivalDate;
                            }
                        else
                            {
                            arrivalDateParse = "notvalid";
                            }
    
                        bool depart = DateTime.TryParseExact(getDepartureDate, dteFormat, new CultureInfo("en-GB"), DateTimeStyles.None, out result);
                        if (depart)
                            {
                            departureDateParse = getDepartureDate;
                            }
                        else
                            {
                            departureDateParse = "notvalid";
                            }
    
                        if (arrivalDateParse == "notvalid" || departureDateParse == "notvalid")
                            {
                            if (Request.IsAjaxRequest())
                                {
                                return Json(new { Confirm = "Date not in correct format" }, JsonRequestBehavior.AllowGet);
                                }
                            else
                                {
                                TempData["Error"] = "Sorry your arrival date or departure date is not a valid format, please enter date as dd/mm/yyyy example 02/12/2013";
                                return View("~/Views/Shared/Error.cshtml");
                                }
