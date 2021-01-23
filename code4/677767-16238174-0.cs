    var query =
                        from c in
                            (from line in File.ReadAllLines(excelFile)
                                let transactionRecord = line.Split(',')
                                select new Transaction()
                                {
                                    TxnId = transactionRecord[12],
                    
                                })
                        where ((string.IsNullOrEmpty(c.TxnId) == false) && (c.TxnId != "Billing Information|Transaction ID"))
                        select c;
