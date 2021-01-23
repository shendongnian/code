    <behaviors>
      <serviceBehaviors>
        <behavior name="Framework.Services.FrameworkBehaviour">
          ...
          <serviceAuthorization principalPermissionMode="UseAspNetRoles" roleProviderName="CustomProvider" />
          <serviceCredentials>
            <serviceCertificate ... />
            <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="...." />
          </serviceCredentials>
        </behavior>
