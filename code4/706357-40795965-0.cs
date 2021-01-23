    using System;
     using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
					
    public class Program
    {
    	public static void Main()
    	{
		//Initializing a collection of 4 Employees fromthree Different departments <Name of Employee, Dept ID>
		List<KeyValuePair<string, int>> EmployeeDept = new List<KeyValuePair<string, int>> {
			new KeyValuePair<string, int> ("Gates",2),
			new KeyValuePair<string, int> ("Nadella",2),
				new KeyValuePair<string, int> ("Mark",3),
			new KeyValuePair<string, int> ("Pichai",4)
		};
		
		//Filter the Employees belongs to these department
		int[] deptToFilter ={3,4};
		
		//Approach 1 - Using COntains Method
		Console.WriteLine ("Approach 1 - Using Contains");
		Console.WriteLine ("==========================================");	
		var filterdByContains = EmployeeDept.Where(emp => deptToFilter.Contains(emp.Value));
		foreach (var dept3and4employees in filterdByContains)
		{
			Console.WriteLine(dept3and4employees.Key+" - "+dept3and4employees.Value);
		}
	
		//Approach 2 Using Join
		Console.WriteLine ("\n\nApproach 2 - Using Join");
		Console.WriteLine ("==========================================");	
		var filteredByJoin = EmployeeDept.Join(
			deptToFilter,
			empdept => empdept.Value, 
			filterdept => filterdept, 
			(empdep,filddep) => new KeyValuePair<string, int>(empdep.Key, empdep.Value)
		);
		
		foreach (var dept3and4employees in filteredByJoin)
		{
			Console.WriteLine(dept3and4employees.Key+" - "+dept3and4employees.Value);
		}
		
	}
    }
