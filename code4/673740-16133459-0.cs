    .BindTo(Model.FloorPlanGroups, mappings =>
    {
         mappings.For<Asis.Ibss.Web.Mvc.Areas.Monitoring.Models.FloorPlanGroupModel>(itemDataBound =>
        itemDataBound.ItemDataBound((item, group) =>
        {
           item.Text = group.Name;
           item.HtmlAttributes["data-groupid"] = group.Id;
           if(group.Id==5){
                item.Selected=true;
           }
         })
