	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;
	using System.Web.Routing;
	using System.Web;
	using System.Linq;
	using System.Reflection;
	namespace ********.Code
	{
		public class CustomRouteConstraint : IRouteConstraint
		{
			private static string controllerNamespace;
			RoutePatternCollection patternCollection { get; set; }
			/// <summary>
			/// Initializes a new instance of the <see cref="CustomRouteConstraint"/> class.
			/// </summary>
			/// <param name="rPC">The route pattern collection to match.</param>
			public CustomRouteConstraint(RoutePatternCollection rPC)
			{
				this.patternCollection = rPC;
				if (string.IsNullOrWhiteSpace(controllerNamespace)) {
					controllerNamespace = Assembly.GetCallingAssembly().FullName.Split(new string[1] {","}, StringSplitOptions.None)
						.FirstOrDefault().Trim().ToString();
				}
			}
			/// <summary>
			/// Sets the controller namespace. Should be called before RegisterRoutes.
			/// </summary>
			/// <param name="_namespace">The namespace.</param>
			public static void SetControllerNamespace(string _namespace)
			{
				controllerNamespace = _namespace;
			}
			/// <summary>
			/// Attempts to match the current request to an action with the constraint pattern.
			/// </summary>
			/// <param name="httpContext">The current HTTPContext of the request.</param>
			/// <param name="route">The route to which the constraint belongs.</param>
			/// <param name="paramName">Name of the parameter (irrelevant).</param>
			/// <param name="values">The url values to attempt to match.</param>
			/// <param name="routeDirection">The route direction (this method will ignore URL Generations).</param>
			/// <returns>True if a match has been found, false otherwise.</returns>
			public bool Match(HttpContextBase httpContext, Route route, string paramName, RouteValueDictionary values, RouteDirection routeDirection)
			{
				if (routeDirection.Equals(RouteDirection.UrlGeneration)) {
					return false;
				}
				Dictionary<string, object> unMappedList = values.Where(x => x.Key.Contains("param")).OrderBy(xi => xi.Key).ToDictionary(
					kvp => kvp.Key, kvp => kvp.Value);
				string controller = values["controller"] as string;
				string action = values["action"] as string;
				Type cont = TryFindController(controller);
				if (cont != null) {
					MethodInfo actionMethod = cont.GetMethod(action);
					if (actionMethod != null) {
						ParameterInfo[] methodParameters = actionMethod.GetParameters();
						if (validateParameters(methodParameters, unMappedList)) {
							for (int i = 0; i < methodParameters.Length; i++) {                            
								var key = unMappedList.ElementAt(i).Key;
								var value = values[key];
								values.Remove(key);
								values.Add(methodParameters.ElementAt(i).Name, value);
							}
							return true;
						}
					}
				}
				return false;
			}
			/// <summary>
			/// Validates the parameter lists.
			/// </summary>
			/// <param name="methodParameters">The method parameters for the found action.</param>
			/// <param name="values">The parameters from the RouteValueDictionary.</param>
			/// <returns>True if the parameters all match, false if otherwise.</returns>
			private bool validateParameters(ParameterInfo[] methodParameters, Dictionary<string, object> values)
			{
				//@TODO add flexibility for optional parameters
				if (methodParameters.Count() != patternCollection.parameters.Count()) {
					return false;
				}
				for (int i = 0; i < methodParameters.Length; i++) {
					if (!matchType(methodParameters[i], patternCollection.parameters.ElementAt(i), values.ElementAt(i).Value)) {
						return false;
					}
				}
				return true;
			}
			/// <summary>
			/// Matches the type of the found action parameter to the expected parameter, also attempts data conversion.
			/// </summary>
			/// <param name="actualParam">The actual parameter of the found action.</param>
			/// <param name="expectedParam">The expected parameter.</param>
			/// <param name="value">The value of the RouteValueDictionary corresponding to that parameter.</param>
			/// <returns>True if the parameters match, false if otherwise.</returns>
			private bool matchType(ParameterInfo actualParam, ParamType expectedParam, object value)
			{
				try {
					switch (expectedParam) {
						case ParamType.BOOL:
							switch (actualParam.ParameterType.ToString()) {
								case "System.Boolean":
									Convert.ToBoolean(value);
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						case ParamType.DOUBLE:
							switch (actualParam.ParameterType.ToString()) {
								case "System.Double":
									Convert.ToDouble(value);
									return true;
									break;
								case "System.Decimal":
									Convert.ToDecimal(value);
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						case ParamType.INT:
							switch (actualParam.ParameterType.ToString()) {
								case "System.Int32":
									Convert.ToInt32(value);
									return true;
									break;
								case "System.Int16":
									Convert.ToInt16(value);                                
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						case ParamType.LONG:
							switch (actualParam.ParameterType.ToString()) {
								case "System.Int64":
									Convert.ToInt64(value);
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						case ParamType.STRING:
							switch (actualParam.ParameterType.ToString()) {
								case "System.String":
									Convert.ToString(value);
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						case ParamType.UINT:
							switch (actualParam.ParameterType.ToString()) {
								case "System.UInt32":
									Convert.ToUInt32(value);
									return true;
									break;
								case "System.UInt16":
									Convert.ToUInt16(value);
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						case ParamType.ULONG:
							switch (actualParam.ParameterType.ToString()) {
								case "System.UInt64":
									Convert.ToUInt64(value);
									return true;
									break;
								default:
									return false;
									break;
							}
							break;
						default:
							return false;
					}
				} catch (Exception) {
					return false;
				}
			}
			/// <summary>
			/// Attempts to discover a controller matching the one specified in the route.
			/// </summary>
			/// <param name="_controllerName">Name of the controller.</param>
			/// <returns>A System.Type containing the found controller, or null if the contoller cannot be discovered.</returns>
			private Type TryFindController(string _controllerName)
			{
				string controllerFullName;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (!string.IsNullOrWhiteSpace(controllerNamespace)) {
					controllerFullName = string.Format(controllerNamespace + ".Controllers.{0}Controller", _controllerName);
					Type controller = executingAssembly.GetType(controllerFullName);
					if (controller == null) {
						if (controllerNamespace.Contains("Controllers")) {
							controllerFullName = string.Format(controllerNamespace + ".{0}Controller", _controllerName);
							if ((controller = executingAssembly.GetType(controllerFullName)) == null) {
								controllerFullName = string.Format(controllerNamespace + ".{0}", _controllerName);
								controller = executingAssembly.GetType(controllerFullName);
							}
						} else {
							controllerFullName = string.Format(controllerNamespace + "Controllers.{0}", _controllerName);
							controller = executingAssembly.GetType(controllerFullName);
						}
					}
					return controller;
				} else {
					controllerFullName = string.Format(Assembly.GetExecutingAssembly().FullName.Split(new string[1] {","}, StringSplitOptions.None)
						.FirstOrDefault().Trim().ToString() + ".Controllers.{0}Controller", _controllerName);
					
					return Assembly.GetExecutingAssembly().GetType(controllerFullName);
				}            
			}
		}
		/// <summary>
		/// A list of the exepected parameters in the route.
		/// </summary>
		public struct RoutePatternCollection
		{
			public List<ParamType> parameters { get; set; }
			public RoutePatternCollection(List<ParamType> _params) : this()
			{
				this.parameters = _params;
			}
		}
		/// <summary>
		/// The valid parameter types for a Custom Route Constraint.
		/// </summary>
		public enum ParamType
		{
			STRING,
			INT,
			UINT,
			LONG,
			ULONG,
			BOOL,
			DOUBLE
		}
	}
