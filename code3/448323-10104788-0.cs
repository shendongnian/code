    public bool UpdateOfficeApprovers(IList<int> invoiceLinesToUpdate, int userId)
    {   
        foreach (var invoiceLineId in invoiceLinesToUpdate)
        {
            var invoiceLine = _unitOfWork.InvoiceLineRepository.Get(invoiceLineId);
        
        if (invoiceLine.HasTwoUniqueApprovers)
        {
            invoiceLine.OfficeUserId = userId;
        }
    }
    _unitOfWork.Save();
    return hasUniqueApprovers;
    }
