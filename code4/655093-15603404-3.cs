    class MainClass
	{
		private static int X = 3, Z = 5, Y = 10;
		public static void Main (string[] args)
		{
			string eqn = "2.5Y * 78Z * 4X / 3 + H * 3N";
			string regex = "(?<var>[a-z])|(?<int>(\\d+(\\.\\d+))|(\\d+))(?<var>[a-z])";
			
			Regex r = new Regex (regex, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
			MatchCollection m = r.Matches (eqn);
			if (m.Count > 0) 
            {
				foreach (Match ma in m) {
					MatchVar (ma);
				}
			}
		}
		private static void MatchVar (Match m)
		{
			string stringValue = string.IsNullOrEmpty (m.Groups ["int"].ToString ()) ? "1" : m.Groups ["int"].ToString ();
			double value = double.Parse (stringValue);
			string var = m.Groups ["var"].ToString ();
			switch (m.Groups ["var"].ToString ()) 
            {
			    case "X":
                    Console.WriteLine ("Result for {0}: {1}", var, value * X);
				    break;
			    case "Z":
				    Console.WriteLine ("Result for {0}: {1}", var, value * Z);
				    break;
			    case "Y":
				    Console.WriteLine ("Result for {0}: {1}", var, value * Y);
				    break;
			    default: 
				    Console.WriteLine ("No value defined for {0}", var);	
				    break;
			}
		}
	}
