    /// <summary>
    /// Emits an opinion about a component's lifestyle only if there are exactly two available handlers and one of them has a PerWebRequest lifestyle.
    /// </summary>
    public class LifestyleSelector : IHandlerSelector
    {
        public bool HasOpinionAbout(string key, Type service)
        {
            return service != typeof(object); // for some reason, Castle passes typeof(object) if the service type is null.
        }
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            if (handlers.Length == 2 && handlers.Any(x => x.ComponentModel.LifestyleType == LifestyleType.PerWebRequest))
            {
                if (HttpContext.Current == null)
                {
                    return handlers.Single(x => x.ComponentModel.LifestyleType != LifestyleType.PerWebRequest);
                }
                else
                {
                    return handlers.Single(x => x.ComponentModel.LifestyleType == LifestyleType.PerWebRequest);
                }
            }
            return null; // we don't have an opinion in this case.
        }
    }
