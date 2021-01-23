      <configuration>
       <location path="~/About.aspx">
          <system.web>
             <authorization>
                <deny users="*"/>
                <allow roles="ADMIN"/>
             </authorization>
          </system.web>
       </location>
       <location path="~/Forms/frmCensus.aspx">
          <system.web>
             <authorization>
                <deny users="*"/>
                <allow roles="CENSUS,ADMIN,ETC"/>
             </authorization>
          </system.web>
       </location>
    </configuration>
     <system.web
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
