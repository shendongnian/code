    public static IEnumerable<SelectListItem> GetDistanceUnits(string distanceUnit)
    {
        var distanceUnitList = GetUnits()
                                    .Select(u =>
                                        new SelectListItem
                                            {
                                                Value = u.OptionValue,
                                                Text = u.OptionName,
                                                Selected = u.OptionSelected == distanceUnit
                                            })
                                    .OrderByAscending(c => c.Text)
                                    .ToList();
        
        return distanceUnitList;
    }
    
    private static IEnumerable<DistanceUnit> GetUnits()
    {
        yield return new DistanceUnit
                        {
                            OptionValue = "mi";
                            OptionName = "Miles";
                            OptionSelected = "";
                        };
                        
        yield return new DistanceUnit
                        {
                            OptionValue = "km";
                            OptionName = "Kilometers";
                            OptionSelected = "";
                        };
    }
