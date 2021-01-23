      <configuration>
       <location path="~/About.aspx">
          <system.web>
             <authorization>
                <allow roles="ADMIN"/>
                <deny users="*"/>
             </authorization>
          </system.web>
       </location>
       <location path="~/Forms/frmCensusList.aspx">
          <system.web>
             <authorization>
                <allow roles="CENSUS,ADMIN,ETC"/>
                <deny users="*"/>
             </authorization>
          </system.web>
       </location>
      <location path="~/Forms/frmRoster.aspx">
          <system.web>
             <authorization>
                <allow roles="ADMIN,ROSTER"/>
                <deny users="*"/>
             </authorization>
          </system.web>
       </location>
       ...
    </configuration>
     <system.web>
      <siteMap defaultProvider="XmlSiteMapProvider" enabled="true">
        <providers>
          <add name="XmlSiteMapProvider"
            description="Default SiteMap provider."
            type="System.Web.XmlSiteMapProvider "
            siteMapFile="Web.sitemap"
            securityTrimmingEnabled="true" />
        </providers>
      </siteMap>
    </system.web>
