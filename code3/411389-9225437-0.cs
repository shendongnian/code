    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    
    namespace ConsoleApplication1 {
    	public class Month {
    		public int MonthID { get; set; }
    		public string MonthName { get; set; }
    		public int NoDays { get; set; }
    	}
    
    	internal class Program {
    		private static void Main(string[] args) {
    			// Build up months
    			var months = new List<Month>();
    			for (var i = 1; i <= 12; i++) {
    				months.Add(new Month {
    					MonthID = i,
    					MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
    					NoDays = DateTime.DaysInMonth(2012, i)
    				});
    			}
    
    			var w = months.Select(m => new {
    				m.MonthName
    			});
    
    			var x = months.Select(m => new {
    				m.MonthName
    			});
    
    			var y = months.Select(m => new {
    				m.MonthName
    			});
    
    			var z = w.Union(x).Union(y);
    
    			foreach (var m in z) {
    				Console.WriteLine(m.MonthName);
    			}
    			Console.Read();
    		}
    	}
    }
