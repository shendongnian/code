      using ( var client = ServiceFactory.CreateChannel() )
      {
        var userInformation = client.GetUserInformation( User.Identity.Name );
    
        if ( userInformation is UserInfoNotEnrolledResult )
        {
          return RedirectToAction( ((UserInfoNotEnrolledResult)userInformation).UserIsValid ? "NoAccess" : "Register" );
        }
    
        var enrolledUserInformation = (UserInfoEnrolledResult)userInformation;
    
        var viewModel = new ViewModel( enrolledUserInformation.UserOptions, enrolledUserInformation.Items );
    
        return View( viewModel );
      }
