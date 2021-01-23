    // Setup the trust level
    var deployment = ApplicationDeployment.CurrentDeployment;
    var appId = new ApplicationIdentity(deployment.UpdatedApplicationFullName);
    var unrestrictedPerms = new PermissionSet(PermissionState.Unrestricted);
    var appTrust = new ApplicationTrust(appId) {
        DefaultGrantSet = new PolicyStatement(unrestrictedPerms),
        IsApplicationTrustedToRun = true,
        Persist = true
    };
    ApplicationSecurityManager.UserApplicationTrusts.Add(appTrust);
    // Check for update
    var info = deployment.CheckForDetailedUpdate();
