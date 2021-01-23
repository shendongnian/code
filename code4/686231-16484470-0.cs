    var session = SessionManager.GetCurrentSession();
    var data2 = session.Query<CPayment>().Select(row => new CPaymentModel()
    {
        CardNo = row.CardNo,
        Product = row.ProductDetails.Product,
        Subproduct = row.ProductDetails.Subproduct,
        FileDate = row.FileDate,
        Transaction =new TransactionHelper()
        {
            TransCode = row.Transaction.TransCode;
            TransDate = row.Transaction.TransDate
        }
    }).ToList<CPaymentModel>();
    var list = data2.ToDataSourceResult(dsRequest);
