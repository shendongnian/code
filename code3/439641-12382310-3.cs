        <membership>
            <providers>
                <clear/>
                <add name="AspNetSqlMembershipProvider" 
                     type="System.Web.Security.SqlMembershipProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" 
                     connectionStringName="ScqMember_Context" 
                     enablePasswordRetrieval="false" enablePasswordReset="true" 
                     requiresQuestionAndAnswer="true" applicationName="/" 
                     requiresUniqueEmail="false" passwordFormat="Hashed" 
                     maxInvalidPasswordAttempts="5" minRequiredPasswordLength="7" 
                     minRequiredNonalphanumericCharacters="1" 
                     passwordAttemptWindow="10" passwordStrengthRegularExpression="" />
            </providers>
        </membership>
        <profile>
            <providers>
                <clear/>
                <add name="AspNetSqlProfileProvider" 
                     connectionStringName="ScqMember_Context" 
                     applicationName="/" 
                     type="System.Web.Profile.SqlProfileProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
            </providers>
        </profile>
        <roleManager enabled="true">
            <providers>
                <clear />
                <add connectionStringName="ScqMember_Context" 
                     applicationName="/"
                     name="AspNetSqlRoleProvider" 
                     type="System.Web.Security.SqlRoleProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
            </providers>
        </roleManager>
