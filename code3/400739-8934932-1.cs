    using Rxx.Parsers.Reactive.Linq;
    
    public sealed class SplitLab : BaseConsoleLab
	{
		protected override void Main()
		{
            var xs = Observable.Generate(
	        	new[] { 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 }.GetEnumerator(),
	     		e => e.MoveNext(),
	     		e => e,
	    	    e => (int) e.Current,
	    		e => TimeSpan.FromSeconds(.5));
  
    		var query = xs.Parse(parser =>
    			from next in parser
    			let one = next.Where(value => value == 1)
    			let other = next.Not(one)
    			let window = from start in one
    						from remainder in other.NoneOrMore()
    						select remainder.StartWith(start)
    			let windowAsString = window.Join()
    			select windowAsString);
    
    		using (query.Subscribe(TraceLine))
    		{
    			WaitForKey();
    		}
        }
    }
