    using System;
    using System.Collections;
    namespace NUnit.Core
    {
    	public interface ITest
    	{
    		TestName TestName
    		{
    			get;
    		}
    		string TestType
    		{
    			get;
    		}
    		RunState RunState
    		{
    			get;
    			set;
    		}
    		string IgnoreReason
    		{
    			get;
    			set;
    		}
    		int TestCount
    		{
    			get;
    		}
    		IList Categories
    		{
    			get;
    		}
    		string Description
    		{
    			get;
    			set;
    		}
    		IDictionary Properties
    		{
    			get;
    		}
    		bool IsSuite
    		{
    			get;
    		}
    		ITest Parent
    		{
    			get;
    		}
    		IList Tests
    		{
    			get;
    		}
    		int CountTestCases(ITestFilter filter);
    	}
    }
