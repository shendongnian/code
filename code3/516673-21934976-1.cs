            protected void myLinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
            {
                e.Result = new List<BranchDataClass>();
                if (!this.IsInSearchingMode)
                    return; 
    
    // e.result = select code 
    }
