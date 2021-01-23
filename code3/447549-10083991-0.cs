    @model MyModel
    
    @functions {
    
        private class Colors
        {
            public int ColorsId { get; set; }
            public string ColorsName { get; set; }
        }
    
    }
    
    @{
        var list = new List<Colors>()
                    {
                        new Colors() {ColorsId = 1, ColorsName = "Red"},
                        new Colors() {ColorsId = 2, ColorsName = "Blue"},
                        new Colors() {ColorsId = 3, ColorsName = "White"}
                    };
        var colors = new SelectList(list, "ColorsId", "ColorsName", 3);
    }
    
    @Html.DropDownListFor(model => model.colors, colors)
