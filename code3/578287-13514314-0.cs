    // method for template 1 - returns only 3 columns/properties
    private DashBoard CreateDashBoardXxxxxxx(DashBoard item)
    {
        return new DashBoard {
            Property1 = item.Property1,
            Property4 = item.Property2,
            Property3 = item.Property3
        };
    }
    // method for template 2 - returns N columns/properties
    private DashBoard CreateDashBoardYyyyyyyy(DashBoard item)
    {
        return new DashBoard {
            Property1 = item.Property1,
            Property4 = item.Property2,
            
            // Other properties
            // .....
            
            PropertyN = item.PropertyN
        };
    }
