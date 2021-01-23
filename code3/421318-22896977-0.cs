Copy the following code into a file named GetMethodInfo.tt: 
    <#@ template language="C#" #>
    <#@ output extension=".cs" encoding="utf-8" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.Text" #>
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace Tools
    {
        public static class GetMethodInfo
        {
    <# int max = 12;
    for(int i = 0; i <= max; i++) 
    {
    	var builder = new StringBuilder();
    
    	for(int j = 0; j <= i; j++) 
    	{
	    	builder.Append("T");
	    	builder.Append(j);
	    	if(j != i) 
	    	{
	    		builder.Append(", ");
	    	}
	    }
    
	    var T = builder.ToString();
    #>
            public static MethodInfo ForFunc<T, <#= T #>>(Expression<Func<T, <#= T #>>> expression)
            {
                var member = expression.Body as MethodCallExpression;
                if (member != null)
                    return member.Method;
    
                throw new ArgumentException("Expression is not a method", "expression");
            }
    
            public static MethodInfo ForAction<<#= T #>>(Expression<Action<<#= T #>>> expression)
            {
                var member = expression.Body as MethodCallExpression;
    
                if (member != null)
                    return member.Method;
    
                throw new ArgumentException("Expression is not a method", "expression");
            }
    
    <# } #>
        }
    }
