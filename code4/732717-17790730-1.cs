    <connectionStrings>
      <add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=DB4;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\DB4.mdf" />
    </connectionStrings>
    <membership defaultProvider="DefaultMembershipProvider">
      <providers>
        <add name="DefaultMembershipProvider" type="WebMatrix.WebData.SimpleMembershipProvider, WebMatrix.WebData"/>
      </providers>
    </membership>
    <roleManager enabled="true">
      <providers>
        <add name="DefaultRoleProvider" type="WebMatrix.WebData.SimpleRoleProvider, WebMatrix.WebData"/>
      </providers>
    </roleManager>
