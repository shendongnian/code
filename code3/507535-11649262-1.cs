     StringBuilder stringBuilder = new StringBuilder();
     stringBuilder.Append("LOAD DATA INFILE ");
     stringBuilder.Append(Path.Combine("D:\\HHTFiles\\", nm));
     stringBuilder.Append(" INTO TABLE table1.location");
     stringBuilder.Append(" FIELDS TERMINATED BY '-->'"); 
     stringBuilder.Append(" LINES TERMINATED BY (");              
     stringBuilder.Append(Barcode.BinLoc);
     stringBuilder.Append(")");
    
     string qry = stringBuilder.ToString();
