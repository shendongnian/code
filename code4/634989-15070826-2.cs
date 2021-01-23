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
            // let's first get the name of the action parameter whose type matches
            // the entity type we've just found. There should be one and exactly
            // one action argument that matches this query, otherwise you have a 
            // problem with your action signature and we'd better fail quickly here
            string paramName = filterContext
                .ActionDescriptor
                .GetParameters()
                .Single(x => x.ParameterType == entity.GetType())
                .ParameterName;
            // and now let's set its value to the entity
            filterContext.ActionParameters[paramName] = entity;
        }
    }
