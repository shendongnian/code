            string property = item.Trim();
            if (property.IndexOf(' ') > 0)
            {
                string area = string.Empty;
                string locationType = string.Empty;
                string number = property.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First();
                property = property.Replace(number, "").Trim();
    
                // When comma is present, area is always the last
                // and locationType always before it
                if (property.IndexOf(',') > 0)
                {
                    area = property.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Last().Trim();
                    property = property.Replace(area, "").Replace(",", "").Trim();
    
                    locationType = property.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last().Trim();
                    property = property.Replace(" " + locationType, "").Trim();
                }
                else
                {
                    // When comma is not present I have to check
                    // if the string contains a given street suffix
                    // and pick up from there
                    string found = suffixes.Find(x => property.Trim().Contains(" " + x, StringComparison.OrdinalIgnoreCase));
                    if (!string.IsNullOrEmpty(found))
                        found = " " + found; 
                        // need the space otherwise it will delete 
                        // places like ST LEONARD.
    
                    locationType = property.Substring(property.ToLower().IndexOf(found.ToLower()), found.Length).Trim();
    
                    int total = property.ToLower().IndexOf(found.ToLower()) + found.Length;
                    if (property.ToLower().IndexOf(found.ToLower()) > 0 && total < property.Length)
                        area = property.Substring(total, property.Length - total).Trim();
    
                    property = property.Replace(",", "").Trim().Replace(locationType, "").Trim();
                    if (!string.IsNullOrEmpty(area))
                        property = property.Replace(area, "").Trim();
                }
    
                    string name = property;
                    if (prevString != "")
                    {
                        result.Add(new ResultData() { Number = prevString, Name = name, LocationType = locationType, Area = area });
                        string numbersFromString = new String(number.Where(x => x >= '0' && x <= '9').ToArray());
                        if (numbersFromString == "")
                        {
                            string numbersFromString2 = new String(prevString.Where(x => x >= '0' && x <= '9').ToArray());
                            result.Add(new ResultData() { Number = (int)numbersFromString2 + number, Name = name, LocationType = locationType, Area = area });
                        }
                        else
                        {
                            result.Add(new ResultData() { Number = number, Name = name, LocationType = locationType, Area = area });
                        }
                    }
                    else
                    {
                        result.Add(new ResultData() { Number = number, Name = name, LocationType = locationType, Area = area });
                    }
                    prevString = "";
            }
            else
            {
                prevString = property;
            }
        }
