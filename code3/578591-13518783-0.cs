    public ProjectModel
    {
        public string ProjectName { get; set; }
        public int CompanyID { get; set; }
        public List<Company> Companies { get; set; }
        public List<SelectListItem> CompaniesSelectList
        {
            get
            {
                return Companies
                    .Select(c => new SelectListItem
                        {
                            Text = c.CompanyName,
                            Value = c.CompanyID.ToString(),
                            Selected = c.CompanyID == CompanyID
                        })
                    .ToList();
            }
        }
    }
