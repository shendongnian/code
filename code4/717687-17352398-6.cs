    public class Matcher<TMatch>
    {
    	private readonly TMatch _matchObj;
    	private bool _isMatched;
    
    	public Matcher(TMatch matchObj)
    	{
    		this._matchObj = matchObj;
    	}
    
    	public Matcher<TMatch> Case<TCase>(Action<TCase> action) where TCase : TMatch
    	{
    		if(this._matchObj is TCase)
    		{
    			this.DoCase(() => action((TCase)this._matchObj));
    		}
    		return this;
    	}
    
    	public void Default(Action<TMatch> action)
    	{
    		this.DoCase(() => action(this._matchObj));
    	}
    
    	private void DoCase(Action action)
    	{
    		if (!this._isMatched)
    		{
    			action();
    			this._isMatched = true;
    		}
    	}
    }
    
    public static class MatcherExtensions
    {
    	public static Matcher<TMatch> Match<TMatch>(this TMatch matchObj)
    	{
    		return new Matcher<TMatch>(matchObj);
    	}
    }
