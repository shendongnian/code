    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\typroject\TYPROJECT\TYPROJECT\logindb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        billDataSet b1 = new billDataSet();
                    
        SqlDataAdapter s = new SqlDataAdapter("select * from TblOrder",con);
                    
        s.Fill(b1,b1.Tables[0].TableName);
                    
        ReportDataSource rds = new ReportDataSource("orders",b1.Tables[0]);
                    
        this.a.LocalReport.DataSources.Clear();
                    
        this.reportViewer1.LocalReport.DataSources.Add(rds);
                   
        this.reportViewer1.LocalReport.Refresh();
                    
        this.TblOrderTableAdapter.Fill(this.billDataSet.TblOrder, d1.ToString(), 
        
        d2.ToString(), companyid);
                   
        this.reportViewer1.RefreshReport();
