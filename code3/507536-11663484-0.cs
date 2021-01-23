            string nm = txtFilename.Text;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("LOAD DATA INFILE ");
            stringBuilder.Append(Path.Combine("'D:/HHTFiles/", nm));
            stringBuilder.Append("' INTO TABLE `table1`.`location`FIELDS TERMINATED BY '-->'LINES TERMINATED BY '\r\n'(Barcode,BinLoc);");
