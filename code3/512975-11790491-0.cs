    public class SPCompany
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
    
    [HttpPost]
    public ActionResult Create(SPCompanyViewModel viewModel)
    {
        var spCompany = new SPCompany
        {
            CompanyName = viewModel.CompanyName,
        };
        db.SPCompany.Add(spCompany);
        db.SaveChanges();
        var spCompanyId = spCompany.Id //there you get id of new record
        return RedirectToAction("Index");
    }
