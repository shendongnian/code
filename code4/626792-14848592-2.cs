    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <system.net>
            <mailSettings>
                <smtp deliveryMethod="Network" from="gdkpavan@gmail.com">
                    <network defaultCredentials="true" host="smtp.gmail.com" password="nprao@1111" port="587" userName="pranayn5@gmail.com" />
                </smtp>
            </mailSettings>
        </system.net>
        <connectionStrings>
            <add name="con" connectionString="Data Source=moviemaster.db.10502677.hostedresource.com; Initial Catalog=picketmaster; User ID=picketmaster; Password=Picket@500;" />
        </connectionStrings>
        <system.webServer>
            <httpErrors errorMode="Detailed" />
    	  <asp scriptErrorSentToBrowser="true" />
        </system.webServer>
        <system.web>
            <compilation debug="true">
                <assemblies>
                    <add assembly="System.Web.Extensions.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
                    <add assembly="System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
                    <add assembly="System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
                </assemblies>
            </compilation>
            <authentication mode="Windows" />
            <customErrors mode="Off" />
            <pages clientIDMode="AutoID" controlRenderingCompatibilityVersion="4.0"/>
            <sessionState mode="InProc" timeout="15" />
        </system.web>
    </configuration>
