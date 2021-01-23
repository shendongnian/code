    using System;
    using System.Text.RegularExpressions;
    class Program {
      static void Main() {
    	string value = "cat\r\ndog\r\nanimal\r\nperson";
    	// Split the string on line breaks.
    	// ... The return value from Split is a string[] array.
    	string[] lines = Regex.Split(value, "\r\n");
    
    	foreach (string line in lines) {
    	    Console.WriteLine(line);
	    }
      }
    }
