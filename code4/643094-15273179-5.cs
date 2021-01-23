    var user = (from u in db.tbl_UserServiceAreaDetails
            where u.tbl_User.UserName.Equals(txt_LoginName.Text)
            && u.tbl_User.Password.Equals(txt_Password.Text)
            select u).FirstOrDefault();
    
          if (user != null)
            {
            var serviceAreaID = user.serviceAreaID;
            var serviceArea = user.tbl_ServiceArea.ServiceArea;
            
            UserClass userDetails = new UserClass();
            
            userDetails.UserName = user.tbl_User.UserName;
            
            foreach (var item in serviceArea)
            {
                userDetails.ServiceAreaDictionary.Add([SOME UNIQUE KEY HERE], new ServiceArea(serviceAreaID, serviceArea));                
            }
            Session["User"] = userDetails;
