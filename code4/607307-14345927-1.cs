    public string GetSubCategory(string category, string subcategory)
        {
            string returnval = "<option></option>";
            if (!string.IsNullOrEmpty(subcategory))
            {
                foreach (
                    var cat in
                        db.Categories.Where(c => c.category1 == category && c.subcategory1 == subcategory)
                          .Select(c => c.subcategory2)
                          .Distinct())
                {
                    if (!string.IsNullOrEmpty(cat.Trim()))
                        returnval += "<option>" + cat + "</option>";
                }
                return returnval;
            }
            return Enumerable.Aggregate(db.Categories.Where(c => c.category1 == category).Select(c => c.subcategory1).Distinct().Where(cat => !string.IsNullOrEmpty(cat.Trim())), returnval, (current, cat) => current + ("<option>" + cat + "</option>"));
        }
