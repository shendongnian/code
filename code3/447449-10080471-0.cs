    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace SODemo
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string segment = "51.54398, -0.27585;51.55175, -0.29631;51.56233, -0.30369;51.57035, -0.30856;51.58157, -0.31672;51.59233, -0.3354";
    			
    			var re = new Regex(@"\s*(?<lat>[-+]?[0-9.]+),\s*(?<lon>[-+]?[0-9.]+)\s*;", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    			var locations = re.Matches(segment).Cast<Match>().Select(m => new 
    			{
    				Lat  = decimal.Parse(m.Groups["lat"].Value, CultureInfo.CreateSpecificCulture("en-US")),
    				Long = decimal.Parse(m.Groups["lon"].Value, CultureInfo.CreateSpecificCulture("en-US")),
    			});
    				
    			foreach (var l in locations)
    			    Console.WriteLine(l);
    		}
    	}
    }
