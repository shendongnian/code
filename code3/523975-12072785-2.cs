    var wsdetails = (from assetTable in Repository.Asset 
                     join userAsset in Repository.UserAsset on 
                     assetTable.Asset_Id equals userAsset.Asset_Id 
                     join subLocationTable in Repository.SubLocation on 
                     assetTable.Sub_Location_Id equals subLocationTable.Sub_Location_ID 
                     where userAsset.User_Id == userCode 
                     && assetTable.Asset_TypeId == 1 && assetTable.Asset_SubType_Id == 1 
                     select new { workstation = subLocationTable.Sub_Location_Name, location = assetTable.Location_Id }).FirstOrDefault();  
 
    result = (from emp in this.Repository.Employee 
              join designation in this.Repository.Designation on 
              emp.DesignationId equals designation.Id 
              where emp.Code == userCode 
              select new EmployeeDetails 
              {                              
                  firstname = emp.FirstName, 
                  lastname = emp.LastName,                               
                  designation = designation.Title
               }).SingleOrDefault();
    result.LocationId = wsdetails != null ? wsdetails.location : "someDefaultValue";
    result.WorkStationName = wsdetails != null ? wsdetails.workstation ?? "someDefaultValue"; 
