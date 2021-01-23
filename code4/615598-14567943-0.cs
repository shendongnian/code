    //
    // Summary:
    //     Initializes a new instance of the System.IdentityModel.Configuration.SecurityTokenServiceConfiguration
    //     class that has the specified issuer name and signing credentials. Settings
    //     are loaded from the specified named configuration.
    //
    // Parameters:
    //   issuerName:
    //     The issuer name. Sets the System.IdentityModel.Configuration.SecurityTokenServiceConfiguration.TokenIssuerName
    //     property.
    //
    //   signingCredentials:
    //     The signing credentials for the STS. Sets the System.IdentityModel.Configuration.SecurityTokenServiceConfiguration.SigningCredentials
    //     property.
    //
    //   serviceName:
    //     The name of the <identityConfiguration> element from which the configuration
    //     is to be loaded.
    public SecurityTokenServiceConfiguration(string issuerName, SigningCredentials signingCredentials, string serviceName);
