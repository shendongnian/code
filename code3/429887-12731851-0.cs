    <system.serviceModel>
      ...
      <behaviors>
         <serviceBehaviors>
           <behavior name=...>
               ...
              <serviceAuthorization principalPermissionMode="UseAspNetRoles"
                            roleProviderName="MyRoleProvider" />
            </behavior>
         </serviceBehaviors>
         ...
