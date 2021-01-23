    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Uri myUri1 = new Uri("http://www.somesite.com/folder/file.jpg?q=randomquery.string");
    			string path1 = String.Format("{0}{1}{2}{3}", myUri1.Scheme, Uri.SchemeDelimiter, myUri1.Authority, myUri1.AbsolutePath);
    			string extension1 = Path.GetExtension(path1);
    			Console.WriteLine("Extension of myUri1: " + extension1);
    
    			Uri myUri2 = new Uri("http://www.somesite.com/folder/?q=randomquerystring");
    			string path2 = String.Format("{0}{1}{2}{3}", myUri2.Scheme, Uri.SchemeDelimiter, myUri2.Authority, myUri2.AbsolutePath);
    			string extension2 = Path.GetExtension(path2);
    			Console.WriteLine("Extension of myUri1: " + extension2);
    			
    			Console.ReadLine();
    		}
    	}
    }
