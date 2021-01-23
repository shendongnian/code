    (from row in
      (from c in DbContext.Customer
       join cd in DbContext.CustomerDetails
       on c.Customer_Id equals cd.CustomerDetail_CustomerId
       join cp in DbContext.ProductPurchases
       on cd.CustomerDetail_OrgID equals cp.ProductPurchase_OrgID
       where cd.CustomerDetail_OrgId == OrganizationID --organization Id is common
       && c.Customer_Org_Id == OrganizationID
       && cp.ProductPurchase_OrgID == OrganizationID
       orderby cd.CustomerDetail_CreatedDate descending
       select new { c, cd, cp })
       select new 
       {
          CustomerId = row.cpd.CustomerDetail_CustomerID,
          CustomerName = row.c.Customer_LastName+", "+row.c.Customer_FirstName,
       }).Distinct().ToList();
