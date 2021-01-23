    using System;
    using static TestEnum.Planet;
    
    namespace TestEnum
    {
    	class Program
    	{
    
    		static void Main(string[] args)
    		{
    			Program p = new Program();
    
    			p.EnumTest();
    
    			Console.WriteLine("\n\nWaiting ...:  ");
    			Console.ReadKey();
    		}
    
    		private void EnumTest()
    		{
    
    			// test:
    			// each admin property: count, ordinal, value, name
    			// each unique property: APlanet, Mass, Radius, G
    			// implicit operator
    			// admin functions: 
    			// admin overrides:
    			// unique properties
    			// unique functions
    
    			Console.WriteLine("\nadmin properties\n");
    			Console.WriteLine("count     | " + Planet.Count + "  (== 9)");
    			Console.WriteLine("ordinal   | " + MERCURY.Ordinal + "  (== 0)");
    			Console.WriteLine("name      | " + MERCURY.Name + " (== MERCURY)");
    			Console.WriteLine("value     | " + MERCURY.Value + " (== 88 Mercury year)");
    
    			double x = EARTH;
    
    			Console.WriteLine("\nadmin Operator\n");
    			Console.WriteLine("Year      | " + x + "  (== 365.2 year)");
    
    			Console.WriteLine("\nadmin functions\n");
    			Console.WriteLine("Compare to| " + MERCURY.CompareTo(EARTH) + "  (== -1)");
    			Console.WriteLine("IsMember  | " + Planet.IsMember("EARTH", true) + "  (== true)");
    			Console.WriteLine("Find      | " + Planet.Find("EARTH", true).Name + "  (== EARTH)");
    			Console.WriteLine("ValueOf   | " + Planet.ValueOf("EARTH").Name + "  (== EARTH)");
    			Console.WriteLine("Equals    | " + EARTH.Equals(MERCURY) + " (== false => EARTH != MERCURY)");
    
    			Console.WriteLine("\n\nunique admin\n");
    			Console.WriteLine("G         | " + Planet.G);
    
    			Console.WriteLine("\nunique properties\n");
    			Console.WriteLine("Enum      | " + MERCURY.Enum);
    			Console.WriteLine("Mass      | " + MERCURY.Mass);
    			Console.WriteLine("Radius    | " + MERCURY.Radius);
    			Console.WriteLine("amount    | " + MERCURY.Amount + "  (== 1 MERCURY first planet)");
    
    			Console.WriteLine("\n\nunique functions");
    
    			// typical Java enum usage example
    
    			double earthWeight = 175; // lbs
    
    			double mass = earthWeight / EARTH.SurfaceGravity();
    
    			Console.WriteLine("\ncalc weight via foreach\n");
    
    			foreach (Planet p in Planet.Members())
    			{
    				Console.WriteLine("Your weight on {0} is {1:F5}",
    					p.Name, p.SurfaceWeight(mass));
    			}
    
    			// end, typical Java enum usage example
    
    			// test Values
    
    			Planet[] planets = Planet.Values();
    
    			Console.WriteLine("\ncalc weight  via array\n");
    
    			foreach (Planet p in planets)
    			{
    				Console.WriteLine("Your weight on {0} is {1:F5}",
    					p.Name, p.SurfaceWeight(mass));
    			}
    
    			// test switch
    			Planet planet = PLUTO;
    
    			Console.WriteLine("\nuse switch - looking for PLUTO\n");
    
    			switch (planet.Enum)
    			{
    			case Planet.planet.EARTH:
    				{
    					Console.WriteLine("found EARTH\n");
    					break;
    				}
    			case Planet.planet.JUPITER:
    				{
    					Console.WriteLine("found JUPITER\n");
    					break;
    				}
    			case Planet.planet.PLUTO:
    				{
    					Console.WriteLine("found PLUTO\n");
    					break;
    				}
    			}
    
    			// these will use implicit value
    			Console.WriteLine("\ntest comparison checks\n");
    			if (EARTH == EARTH)
    			{
    				Console.WriteLine("\npassed - EARTH == EARTH\n");
    			}
    
    			if (MERCURY < EARTH)
    			{
    				Console.WriteLine("passed - MERCURY < EARTH\n");
    			}
    
    			if (PLUTO > EARTH)
    			{
    				Console.WriteLine("passed - PLUTO > EARTH\n");
    			}
    
    			// test enum extension
    
    			Console.WriteLine("\nbonus - enum extension\n");
    			Console.WriteLine("PLUTO AsShort| " + Planet.planet.PLUTO.Value() + "  (9th planet)");
    
    
    			// test ValueOf failure
    			Console.WriteLine("\n\nValueOf that fails\n");
    			try
    			{
    				planet = Planet.ValueOf("xxx");
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine(e);
    			}
    
    		}
    	}
    }
