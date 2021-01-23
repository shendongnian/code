        <roleManager enabled="true" defaultProvider="SimpleRoleProvider">
            <providers>
                <clear />
                <add name="SimpleRoleProvider" type="WebMatrix.WebData.SimpleRoleProvider, WebMatrix.WebData" />
            </providers>
        </roleManager>
        <membership defaultProvider="SimpleMembershipProvider">
            <providers>
                <clear />
                <add name="SimpleMembershipProvider" type="WebMatrix.WebData.SimpleMembershipProvider, WebMatrix.WebData" />
            </providers>
        </membership>
        <sessionState mode="InProc" customProvider="DefaultSessionProvider">
            <providers>
                <add name="DefaultSessionProvider" type="System.Web.Providers.DefaultSessionStateProvider, System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" connectionStringName="DefaultConnection" />
            </providers>
        </sessionState>
