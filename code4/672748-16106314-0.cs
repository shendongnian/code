    using System;
    
    namespace Sitecore.Sharedsource.Shell.Framework.Commands.System
    {
      [Serializable]
      public class Debug : Sitecore.Shell.Framework.Commands.Command
      {
        public override void Execute(
          Sitecore.Shell.Framework.Commands.CommandContext context)
        {
          Context.ClientPage.ClientResponse.CheckModified(false);
          Sitecore.Data.Database contentDatabase = Context.ContentDatabase;
    
          if ((context.Items != null) && (context.Items.Length == 1))
          {
            Sitecore.Data.Database database = context.Items[0].Database;
          }
    
          Sitecore.Text.UrlString webSiteUrl = 
            Sitecore.Sites.SiteContext.GetWebSiteUrl();
          webSiteUrl.Add("sc_debug", "1");
    
          if ((context.Items != null) && (context.Items.Length == 1))
          {
            Sitecore.Data.Items.Item item = context.Items[0];
    
            if (item.Visualization.Layout != null)
            {
              webSiteUrl.Add("sc_itemid", item.ID.ToString());
            }
    
            webSiteUrl.Add("sc_lang", item.Language.ToString());
          }
    
          if (contentDatabase != null)
          {
            webSiteUrl.Add("sc_database", contentDatabase.Name);
          }
    
          webSiteUrl.Add("sc_prof", "1");
          webSiteUrl.Add("sc_trace", "1");
          webSiteUrl.Add("sc_ri", "1");
          Context.ClientPage.ClientResponse.Eval(
            "window.open('" + webSiteUrl + "', '_blank')");
        }
      }
    }
