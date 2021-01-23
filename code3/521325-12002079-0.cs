    protected void btnExport_Click(object sender, EventArgs e) 
            {    
                  var datasource;
                  if (this.RadioButtonList1.SelectedIndex == 1)     
                   {         
                      int pageSize = 10; 
                      datasource= GridViewDatasourceCollection.Skip(pageSize * pageNumber).Take(pageSize);    
                      this.GridView1.DataSource= datasource;    
                      this.GridView1.DataBind();     
                   }     
                   else if (this.RadioButtonList1.SelectedIndex == 2)     
                   {         
                      //  the user wants all rows exported, have to turn off paging and rebind                
                      this.GridView1.AllowPaging = datasource;         
                      this.GridView1.DataBind();     
                   }     
                   GridViewExportUtil.Export("ContactsInformation.xls", this.GridView1); 
               } 
