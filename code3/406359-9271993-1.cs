    @functions {
        public string DrawControl(string id, ...) 
        {
            return Html.Render("DrawControl", new { id = "ID" });
        }
        // Repeated for all of the overloads of DrawControl
    }
    @DrawControl("ID", ...)
