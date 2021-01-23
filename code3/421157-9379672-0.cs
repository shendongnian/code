    var numericTypes = 
        new [] { typeof(Byte), typeof(Decimal), typeof(Double),
                 typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte),
                 typeof(Single), typeof(UInt16), typeof(UInt32), typeof(UInt64)};
    Decimal lowest;
    foreach(DataColumn col in dtRep.Columns) {
        if(numericTypes.Contains(col.DataType)){
            var minColVal = Convert.ToDecimal(dtRep.Compute(string.Format("MIN({0})", col.ColumnName), "ColName > 0"));
            if(minColVal < lowest) lowest = minColVal;
        }
    }
 
