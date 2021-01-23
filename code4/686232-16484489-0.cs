    var session = SessionManager.GetCurrentSession();
    
     var data2 = session.Query<CPayment>().**Include("CPayment.Transaction").**Select(row => new CPaymentModel()
     {
            CardNo = row.CardNo,
            Product = row.ProductDetails.Product,
            Subproduct = row.ProductDetails.Subproduct,
            FileDate = row.FileDate,
            Transaction =row.Transaction
       }).ToList<CPaymentModel>();
    var list = data2.ToDataSourceResult(dsRequest);
