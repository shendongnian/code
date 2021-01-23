    <serviceBehaviors>
        <behavior name="ServiceBehavior">
          <serviceCredentials>
            <userNameAuthentication userNamePasswordValidationMode="MembershipProvider" membershipProviderName="SQLMembershipProvider"/>
          </serviceCredentials>
          <serviceAuthorization principalPermissionMode="Custom">
            <authorizationPolicies>
              <add policyType="TicketingCore.HttpContextIdentityPolicy, TicketingCore"/>
              <add policyType="TicketingCore.HttpContextPrincipalPolicy, TicketingCore"/>
            </authorizationPolicies>
          </serviceAuthorization>
          <serviceMetadata httpGetEnabled="true"/>
          <serviceDebug includeExceptionDetailInFaults="false"/>
        </behavior>
      </serviceBehaviors>
