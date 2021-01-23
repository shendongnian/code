     public class ContainsConstraint : IHttpRouteConstraint
    {       
        public string[] array { get; set; }
        public bool match { get; set; }
        /// <summary>
        /// Check if param contains any of values listed in array.
        /// </summary>
        /// <param name="param">The param to test.</param>
        /// <param name="array">The items to compare against.</param>
        /// <param name="match">Whether we are matching or NOT matching.</param>
        public ContainsConstraint(string[] array, bool match)
        {
    
            this.array = array;
            this.match = match;
        }
        public bool Match(System.Net.Http.HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (values == null) // shouldn't ever hit this.                   
                return true;
            if (!values.ContainsKey(parameterName)) // make sure the parameter is there.
                return true;
            if (string.IsNullOrEmpty(values[parameterName].ToString())) // if the param key is empty in this case "action" add the method so it doesn't hit other methods like "GetStatus"
                values[parameterName] = request.Method.ToString();
            bool contains = array.Contains(values[parameterName]); // this is an extension but all we are doing here is check if string array contains value you can create exten like this or use LINQ or whatever u like.
            if (contains == match) // checking if we want it to match or we don't want it to match
                return true;
            return false;             
        }
