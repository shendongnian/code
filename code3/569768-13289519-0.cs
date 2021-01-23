    var DRows = from inputRow in inputTable.AsEnumerable()
                     where inputRow.D == 'some value'
                     select new outputRow(inputRow, *delegateToProcessor*)
    
    var ERows = from inputRow in inputTable.AsEnumerable()
                     where inputRow.E == 'some value'
                     select new outputRow(inputRow, *delegateToProcessor*)
    
    var FRows = from inputRow in inputTable.AsEnumerable()
                     where inputRow.F == 'some value'
                     select new outputRow(inputRow, *delegateToProcessor*)
    
    return DRows.Union(ERows).Union(FRows);
