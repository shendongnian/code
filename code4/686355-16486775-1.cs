    using System;
    
    namespace ContextDemo
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			DetectContext();
    			using (new ContextA())
    				DetectContext();
    			using (new ContextB())
    				DetectContext();
    		}
    
    		static void DetectContext()
    		{
    			Context context = Context.Current;
    			if (context == null)
    				Console.WriteLine("No context");
    			else 
    				Console.WriteLine("Context of type: " + context.GetType());
    		}
    	}
    
    	public class Context: IDisposable
    	{
    		#region Static members
    
    		[ThreadStatic]
    		static private Context _Current;
    
    		static public Context Current
    		{
    			get
    			{
    				return _Current;
    			}
    		}
    
    		#endregion
    
    		private readonly Context _Previous;
    
    		public Context()
    		{
    			_Previous = _Current;
    			_Current = this;
    		}
    		
    		public void Dispose()
    		{
    			_Current = _Previous;
    		}
    	}
    
    	public class ContextA: Context
    	{
    	}
    
    	public class ContextB : Context
    	{
    	}
    }
