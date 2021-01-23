    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication1
    {
    	public sealed class Document
    	{
    		public string MemberName { get; set; }
    	}
    
    	public static class Program
    	{
    		public static void Main(string[] args)
    		{
    			// Setup...
    			var documents = new List<Document>();
    
    			documents.Add(new Document { MemberName = "Test 1 + CurrentFilterValue" });
    			documents.Add(new Document { MemberName = "Test 2 + CurrentFilterValue" });
    			documents.Add(new Document { MemberName = "Test 3"});
    
    			// Create the expression tree...
    			var parameter = Expression.Parameter(typeof(Document), "document");
    
    			var isNotNull = Expression.NotEqual(parameter, Expression.Constant(null));
    			
    			var containsIsTrue =
    				Expression.IsTrue(
    					Expression.Call(Expression.Property(parameter, "MemberName"),
    						typeof(string).GetMethod("Contains"),
    						Expression.Constant("CurrentFilterValue")));
    
    			var bothAreTrue = Expression.And(isNotNull, containsIsTrue);
    			var lambda = Expression.Lambda<Func<Document, bool>>(bothAreTrue, parameter).Compile();
    
    			// Test...
    			var results = documents.Where(d => lambda(d));
    		}
    	}
    }
