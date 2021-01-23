        //DLL: Intelligencia.UrlRewriter.dll    
        
        //web.config
        <configuration>
        
          <configSections>
            <section name="rewriter" requirePermission="false" type="Intelligencia.UrlRewriter.Configuration.RewriterConfigurationSectionHandler, Intelligencia.UrlRewriter"/>
          </configSections>
        </configuration>
        
        <system.web>
            <httpModules>
              <add name="UrlRewriter" type="Intelligencia.UrlRewriter.RewriterHttpModule, Intelligencia.UrlRewriter"/>
            </httpModules>
        </system.web>
        
        
        <rewriter>
            <rewrite url="~/(.+)/CompanyHomePage" to="~/Home.aspx"/>
        </rewriter>
        
        
        //C#:
        
         string strTitle = Session["company_name"].ToString();
         strTitle = strTitle.Trim('-');
         strTitle = strTitle.ToLower();
         char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
         strTitle = strTitle.Replace("c#", "C-Sharp");
         strTitle = strTitle.Replace("vb.net", "VB-Net");
         strTitle = strTitle.Replace("asp.net", "Asp-Net");
         strTitle = strTitle.Replace(".", "-");
         
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (strTitle.Contains(strChar))
            {
               strTitle = strTitle.Replace(strChar, string.Empty);
            }
        }
         strTitle = strTitle.Replace(" ", "-");
         strTitle = strTitle.Replace("--", "-");
         strTitle = strTitle.Replace("---", "-");
         strTitle = strTitle.Replace("----", "-");
         strTitle = strTitle.Replace("-----", "-");
         strTitle = strTitle.Replace("----", "-");
         strTitle = strTitle.Replace("---", "-");
         strTitle = strTitle.Replace("--", "-");
         strTitle = strTitle.Trim();
         strTitle = strTitle.Trim('-');
        
         Response.Redirect("~/" + strTitle + "/CompanyHomePage", false);//Redirect to ~/Home.aspx page
    
    
    //reference: CompanyHomePage same in web.config  <rewrite url="~/(.+)/CompanyHomePage" to="~/Home.aspx"/> which company is log in to sight that company name show in url like this http://abcd//CompanyHomePage
