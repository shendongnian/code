        <membership>
          <providers>
           <clear/>
             <add name="AspNetSqlMembershipProvider" type="System.Web.Security.SqlMembershipProvider" connectionStringName="ApplicationServices"
             enablePasswordRetrieval="false" enablePasswordReset="true" requiresQuestionAndAnswer="false" requiresUniqueEmail="false"
             maxInvalidPasswordAttempts="5" minRequiredPasswordLength="6" minRequiredNonalphanumericCharacters="0" passwordAttemptWindow="10"
             applicationName="YourAppName" />
          </providers>
        </membership>
        <profile>
          <providers>
           <clear/>
           <add name="AspNetSqlProfileProvider" type="System.Web.Profile.SqlProfileProvider" connectionStringName="ApplicationServices" applicationName="YourAppName" />
          </providers>
         </profile>
        <roleManager enabled="false">
          <providers>
            <clear/>
            <add name="AspNetSqlRoleProvider" type="System.Web.Security.SqlRoleProvider" connectionStringName="ApplicationServices" applicationName="YourAppName" />
          </providers>
        </roleManager>
