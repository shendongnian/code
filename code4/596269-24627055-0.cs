    using Microsoft.Practices.Unity;
    using System.Web.Http;
    using System.Web.Mvc;
    using Unity.Mvc5;
    DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
