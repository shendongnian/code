           string sqlSorgu = "SELECT" + " customer.id," + " IIf (customer.cins = 'M','Kişi','Qadın') AS Cins " + " FROM customer ORDER BY customer.id ASC"; 
                                                                                                                                                         
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlSorgu, Program.esas.bazayaQosul); 
            DataTable dataTable = new DataTable(); 
            set = new DataSet(); 
            set.Tables.Add(dataTable); 
            dataAdapter.Fill(dataTable);
    
            //  Here is the code for adding new row
            dataTable.Rows.Add(new string[]
                                   {
                                       "0", "1", hesab_nomresi, soyad, ad, ataadi, vesiqe, teskilat_kodu, tevellud, nomre,
                                       cins
                                   });
    
            kartsifarishiGridView.DataSource = dataTable;
     
