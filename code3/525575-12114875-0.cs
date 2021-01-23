    var products = ftjent.AssociationProducts;
    if (affiliationID != null)
        products = products.Where(x => x.AffiliationID = affiliationID);
    var associations = (
        from a in ftjent.Associations
        join ap in products on a.AssociationID equals ap.AssociationID
        where ap.Product.Name == productName
        select new
        {
            a.Acronym,
            a.AssociationID,
            a.Name
        }
    )
    .Distinct()
    .OrderBy(assoc => assoc.Acronym);
