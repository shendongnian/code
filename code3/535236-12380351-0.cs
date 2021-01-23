    using System;
    using System.Diagnostics;
    using Xunit;
    using Xunit.Sdk;
    
    namespace xUnitSample
    {
    	public class SomeFixture : IDisposable
    	{
    		public SomeFixture()
    		{
    			Console.WriteLine("SomeFixture ctor: This should only be run once");
    		}
    
    		public void SomeMethod()
    		{
    			Console.WriteLine("SomeFixture::SomeMethod()");
    		}
    
    		public void Dispose()
    		{
    			Console.WriteLine("SomeFixture: Disposing SomeFixture");
    		}
    	}
    
        public class TestSample : IUseFixture<SomeFixture>, IDisposable
        {
    		public void SetFixture(SomeFixture data)
    		{
    			Console.WriteLine("TestSample::SetFixture(): Calling SomeMethod");
    			data.SomeMethod();
    		}
    
    		public TestSample()
    		{
    			Console.WriteLine("This should be run once before every test " + DateTime.Now.Ticks);
    		}
    
    		[Fact]
    		public void Test1()
    		{
    			Console.WriteLine("This is test one.");
    		}
    
    		[Fact]
    		public void Test2()
    		{
    			Console.WriteLine("This is test two.");
    		}
    
    		public void Dispose()
    		{
    			Console.WriteLine("Disposing");
    		}
    	}
    }
