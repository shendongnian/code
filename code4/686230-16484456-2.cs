    row =>
    {
        CPaymentModel cpModel = new CPaymentModel()
        {
            CardNo = row.CardNo,
            Product = row.ProductDetails.Product,
            Subproduct = row.ProductDetails.Subproduct,
            FileDate = row.FileDate,
            Transaction = new TransactionHelper()
        };
        cpModel.Transaction = new Transaction();
        cpModel.Transaction.TransCode = row.Transaction.TransCode;
        cpModel.Transaction.TransDate = row.Transaction.TransDate;
        return cpModel;
    }
