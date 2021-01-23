    public class EntityLookupAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // retrieve the id parameter from the RouteData
            var id = filterContext.HttpContext.Request.RequestContext.RouteData.Values["id"] as string;
            if (id == null)
            {
                // There was no id present in the request, no need to execute the action
                filterContext.Result = new HttpNotFoundResult();
            }
    
            // we've got an id, let's query the database:
            var entity = db.Entities.Find(id);
            if (entity == null)
            {
                // The entity with the specified id was not found in the database
                filterContext.Result = new HttpNotFoundResult();
            }
    
            // We found the entity => we could associate it to the action parameter
            filterContext.ActionParameters["entity"] = entity;
        }
    }
