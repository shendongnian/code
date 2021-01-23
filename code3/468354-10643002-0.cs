    SecurityClient securityClient = new SecurityClient();
    SecurityService.GetIncomingPermissionsByIdRequest securityRequest = new GetIncomingPermissionsByIdRequest(Convert.ToInt32(recordId));
    SecurityService.GetIncomingPermissionsByIdResponse securityResponse = securityClient.GetIncomingPermissionsById(securityRequest);
    incomingPermissions = securityResponse.GetIncomingPermissionsByIdResult;
    SetPermissionFields();
    SetPermissionList();                  
    securityClient.Close();
    securityClient.Dispose();
