        Dim MyDataTable As DataTable = New DataTable
    	MyDataTable.Columns.Add("ProviderName", GetType(String))
        MyDataTable.Columns.Add("TotalNumSale", GetType(Integer))
        MyDataTable.Columns.Add("TotalValSale", GetType(Double))
        Dim testquery = (From p In adviceProductData _
                                             Where p.IsOffPanel = False _
                                       Group By p.ProviderName _
                                       Into _
                                       totalNoOfSale = Sum(p.NoOfSales), _
                                       totalValueOfSale = Sum(p.ValueOfSales)
                                       Select New With {
                                           .ProvName = ProviderName,
                                            .TotSale = totalNoOfSale,
                                           .TotVal = totalValueOfSale
                                           }).ToList()
        Dim item
        For Each item In testquery
            Dim row = MyDataTable.NewRow()
            row("ProviderName") = item.ProvName
            row("TotalNumSale") = item.TotSale
            row("TotalValSale") = item.TotVal
            MyDataTable.Rows.Add(row)
	    Next
