        [HttpPost]
        public ActionResult ValidateFields(string Desc, string Status, string Name )
        {
            List<string> fields = new List<string>();
            if (string.IsNullOrEmpty(Desc))
                fields.Add("#Desc");
            if (string.IsNullOrEmpty(Status))
                fields.Add("#Status");
            if (string.IsNullOrEmpty(Name))
                fields.Add("#Name");
            // Check if the list "fields" has any items in it.
            if (fields.Any()) {
                 return content("Please enter valid values for " + string.Join(", ", fields)); 
            }
            return content("Validation Successful");
        }
