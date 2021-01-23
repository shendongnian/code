    public string Gender { get; set; }
    public SelectList GenderChoices
    {
        get
        {
            return new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male" },
                    new SelectListItem { Value = "F", Text = "Female" }
                }, "Value", "Text", Gender);
        }
     }
