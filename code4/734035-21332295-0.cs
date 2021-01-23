    In model
    --------
    
    simple example 
    
    
     public class subdomain
       {
    
           public string Function { get; set; }
           public string SubDomain { get; set; }
           public string URL { get; set; }
           public Guid DomainId { get; set; }
           
       }
       public class emailserver
       {
           public string Priority { get; set; }
           public string MailExchanger { get; set; }
           public Guid DomainId { get; set; }
       }
    
    
      public class  tablevalues
       {
           public List<emailserver> emailserver { get; set; }
         
           public List<subdomain> subdomain { get; set; }
       }
    
    
    
    in controller
    -------------
    tablevalues dto=new tablevalues();
    dto.subdomain=from  p in context.tablename1  select p
    dto.emailserver=from q in context.tablename2 select q
    return View(dto);
    
    
    in .cshtml
    ----------
    
    
     @model MVCDropDownlist.Models.tablevalues 
    
    @{
        Layout = null;
    }
    
    
     <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbsub" style="visibility: @(Model.subdomain.Count==0? "hidden" : "visible") " >
                <thead>
                    <tr>
                        <td colspan="3">
                             <h1>Web Settings</h1>
                        </td>
                    </tr>
                    <tr>
                        <th>Web Sub Domain</th>
                        <th>Function</th>
                        <th>Points To</th>
                    </tr>
                </thead>
                <tbody>
                    @if (Model != null && Model.subdomain.Count() > 0)
                    {
                        foreach (var item in Model.subdomain)
                        {
                        <tr>
                            <td>
                                @Html.DisplayFor(modelItem => item.SubDomain)
                            </td>
                            <td>@Html.DisplayFor(modelItem => item.Function)</td>
                            <td>@Html.DisplayFor(modelItem => item.URL)</td>
                        </tr>
                          
                        }
                    }
                </tbody>
    
            </table>
            <!--tableGrid -->
        </div>
    
        <!--rightSection -->
    </div>
    
    <div class="rightSection">
       
        <div class="tableGrid">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbess" style="visibility: @(Model.emailserver.Count==0? "hidden" : "visible") ">
                <thead>
                    <tr>
                        <td colspan="2">
                             <h1>Email Server Settings</h1>
                        </td>
                    </tr>
                    <tr>
                        <th>Mail Exchanger</th>
                        <th>Priority</th>
                    </tr>
                </thead>
                <tbody>
                    @if (Model != null && Model.emailserver.Count() > 0)
                    {
                        foreach (var item in Model.emailserver)
                        {
                            
                        <tr>
                            <td>
                                @Html.DisplayFor(modelItem => item.MailExchanger)
                            </td>
                            <td>@Html.DisplayFor(modelItem => item.Priority)</td>
                        </tr>
                           
                        }
                    }
    
                </tbody>
    
            </table>
            
