     imports BusLogic;
     private void button1_Click(object sender, EventArgs e)
     {
         var pf = new ProcessFiles();
         pf.foo(@"C:\temp","countries.txt"); 
         dataGridView2.AutoGenerateColumns = false;
         dataGridView2.DataSource = pf.CountryDataList;
         multiCountryDataBindingSource.DataSource = pf.MultiCountryDataList;      
     }
         
       
