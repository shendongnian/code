    var numericTypes = 
       new [] { typeof(Byte),   typeof(Decimal), typeof(Double),
                typeof(Int16),  typeof(Int32),   typeof(Int64),  typeof(SByte),
                typeof(Single), typeof(UInt16),  typeof(UInt32), typeof(UInt64)};
    Decimal lowest=Decimal.MaxValue;
    foreach(DataColumn col in dtRep.Columns) {
        if(numericTypes.Contains(col.DataType)){
            var exp=string.Format("MIN({0})"  , col.ColumnName);
            var filter=string.Format("{0} > 0", col.ColumnName);
            var d = Convert.ToDecimal(dtRep.Compute(exp, filter));
            if(d < lowest) lowest = d;
        }
    }
