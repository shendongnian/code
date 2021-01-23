    var sessionList = System.Web.HttpContext.Current.Session["GammeList"] as List<Gamme>;
    if(sessionList != null && sessionList.Count > 0){
       <div id="divGestion">
           <%: Html.Partial("Gestion", Model) %>
       </div>
    }
