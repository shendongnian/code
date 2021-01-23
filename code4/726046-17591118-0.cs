       taxcodeids = db.DisplayData.Where(s=>s.CompanyId == model.OrgId).ToList();
       taxcodelist = db.TaxCodes.AsNoTracking().Distinct().Where(x=> taxcodeids.Contains(y => y.ID == x.TAX_CODE_ID)).OrderBy(s => s.Id).ToList();
       orglist = db.Organizations.AsNoTracking().Distinct().OrderBy(s => s.org_id).ToList();
       model.TaxCodeList = new SelectList(taxcodelist, "ID", "Name");
       model.OrgList = new SelectList(orglist, "org_id", "org_name");
