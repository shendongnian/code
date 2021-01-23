  
 
           
            ClientContext ctx = new ClientContext("http://SiteUrl");
            Web web = ctx.Web;
            List list = web.Lists.GetByTitle("My Task List");
            ListItem listitem = list.GetItemById(1);
            listitem["Completed"] = true;
            listitem["PercentComplete"] = 1;
            listitem["Status"] = "Approved";
            listitem["WorkflowOutcome"] = "Approved";
            listitem.Update();
            ctx.ExecuteQuery();
