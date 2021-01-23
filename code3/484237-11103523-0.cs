	using System.Collections.Generic;
	using System.Web.Mvc;
	using System.Web.Routing;
	using Orchard.Mvc.Routes;
	namespace CentralStationDataView
	{
		public class Routes : IRouteProvider
		{
			public void GetRoutes(ICollection<RouteDescriptor> routes)
			{
				foreach (var routeDescriptor in this.GetRoutes())
				{
					routes.Add(routeDescriptor);
				}
			}
			public IEnumerable<RouteDescriptor> GetRoutes()
			{
				return new[] 
				{
					new RouteDescriptor 
					{
						Priority = 5,
						Route = new Route(
							"AreaName",
							new RouteValueDictionary
							{
								{ "area", "AreaName" },
								{ "controller", "ControllerName" },
								{ "action", "ActionName" }
							},
							new RouteValueDictionary(),
							new RouteValueDictionary 
							{
								{ "area", "AreaName" }
							},
							new MvcRouteHandler())
					}
				};
			}
		}
	}
