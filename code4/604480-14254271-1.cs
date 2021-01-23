    var q_business = _context.BUSINESS.Include(b=>b.CUSTOMSOFFICE)
                              .Where(b => b.BUSINESSNO == int.Parse(pv_businessno)
                                          && b.BUSINESSSTART <= DateTime.Parse(pv_date)
                                          && b.BUSINESSCLOSED >= DateTime.Parse(pv_date) )
                              .Select(b => new {BusinessNo = b.BUSINESSNO,
                                                BusinessName = b.BUSINESSNAME,
                                                CustomsOfficeCode = b.CUSTOMSOFFICE.CUSCODE,
                                                CustomsOfficeDesc = b.CUSTOMSOFFICE.CUSDESC } ) //This Select statement creates a new anonymous type that has Businessno, BusinessName, CustomsOfficeCode, and CustomsOfficeDesc properties
                              .FirstOrDefault();
