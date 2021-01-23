    [Required(ErrorMessage = "Please select a Country")]
    public string CountryCode{ get; set; }
    
    public IEnumerable<SelectListItem> CountryList
    {
        get
        {
            return Country
                .GetAllCountry()
                .Select(Country=> new SelectListItem 
                { 
                    Text = Country.Value, 
                    Value = Country.Value 
                })
                .ToList();
        }
    }
