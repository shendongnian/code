    var query = cases.OrderBy(c => c.CaseTitle + "-" + c.Customer.CustomerDescription)
                     .Select( (c, i) =>
                        new {
                                id = i.ToString(),
                                realid = "c" + c.CaseID.ToString(),
                                title = c.CaseTitle + "-" + c.Customer.CustomerDescription,
                                start = ResolveStartDate(StartDate(c.Schedule.DateFrom.Value.AddSeconds(i))),
                                end = ResolveEndDate(StartDate(c.Schedule.DateFrom.Value), c.Schedule.Hours.Value),
                                description = c.CaseDescription,
                                allDay = false,
                                resource = c.Schedule.EmployeID.ToString(),
                                editable = edit,
                                color = ColorConversion.HexConverter(System.Drawing.Color.FromArgb(c.Color.Value))
                            }
                       );
