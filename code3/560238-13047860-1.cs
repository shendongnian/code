    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Uri myURI1 = new Uri(@"http://www.somesite.com/");
    			Uri myURI2 = new Uri(@"http://www.somesite.com/filenoext");
    			Uri myURI3 = new Uri(@"http://www.somesite.com/filewithext.jpg");
    			Uri myURI4 = new Uri(@"http://www.somesite.com/filewithext.jpg?q=randomquerystring");
    
    			Console.WriteLine("Does myURI1 have an extension: " + Path.HasExtension(myURI1.AbsoluteUri));
    			Console.WriteLine("Does myURI2 have an extension: " + Path.HasExtension(myURI2.AbsoluteUri));
    			Console.WriteLine("Does myURI3 have an extension: " + Path.HasExtension(myURI3.AbsoluteUri));
    			Console.WriteLine("Does myURI4 have an extension: " + Path.HasExtension(myURI4.AbsoluteUri));
    
    			Console.ReadLine();
    		}
    	}
    }
