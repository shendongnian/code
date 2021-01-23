    var myData = this.MyData;
    myData.Add(new MyData() { 
            Area = TextBoxArea.Text, 
            CompanyName = TextBoxCompanyName.Text, 
            Description = TextBoxDescription.Text, 
            From = TextBoxFrom.Text, 
            Sector = TextBoxSector.Text, 
            To = TextBoxTo.Text 
        });
        
    this.MyData = myData;           
    GridViewAllAssigments.DataSource = this.MyData;
    GridViewAllAssigments.DataBind();
