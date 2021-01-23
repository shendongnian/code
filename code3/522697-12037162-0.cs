    var myResult = db.TABLE1
    	.Join(db.TABLE2, t1 => t1.TABLE2_ID, t2 => t2.ID, (t1, t2) => new { Table1 = t1, Table2 = t2 })
    	.Join(db.TABLE3, j => j.Table1.TABLE3_ID, t3 => t3.ID, (j, t3) => new { Table1 = j.Table1, Table3 = j.Table2, Table3 = t3 })
    	.Where(row => row.Table1.ACTIF)
    	.Select(row => new MyClass {
    		T1MyField1 = row.Table1.MyField1,
    		T1MyField2 = row.Table1.MyField2,
    		T2MyField1 = row.Table2.MyField1,
    		...
    		
    	});
