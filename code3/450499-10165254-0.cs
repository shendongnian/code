    Func<QueryOverProjectionBuilder<InvoiceDto>, QueryOverProjectionBuilder<InvoiceDto>> GetList()
    {
    	InvoiceDto dto = null;
    	return list => list.Select(w => w.Client).WithAlias(() => dto.Client);
    }
