	public class MultiOptionSet : OptionSet
	{
		private string lastArg;
		private Option lastOption;
		protected override bool Parse(string argument, OptionContext c)
		{
			// based on example in http://www.ndesk.org/doc/ndesk-options/NDesk.Options/Option.html#M:NDesk.Options.Option.OnParseComplete(NDesk.Options.OptionContext)
			string f, n, s, v;
			bool haveParts = GetOptionParts(argument, out f, out n, out s, out v);
			// reset placeholder for next multiple if we are looking at a flagged argument name
			if( haveParts )
			{
				lastArg = f + n;
			}
			// are we after a flagged argument name, without parts (meaning a value)
			else
			{
				// remember for next time, in case it's another value
				if( null != c.Option ) lastOption = c.Option;
				// but if the 'last arg' wasn't already provided, we reuse the one we set last time
				else
				{
					c.Option = lastOption;
					c.OptionName = lastArg;
				}
				c.OptionValues.Add(argument); // add the value to be invoked
				c.Option.Invoke(c); // perform the 'setter'
				return true;
			}
			
			return base.Parse(argument, c);
		}
	}
