    void Main()
    {
    	Events.Queue(new Message(){ Text = "Hit points +5" });
    	Events.Queue(new Message(){ Text = "Hit points +6" });
    	Events.Queue(new ChuckNorris());
    
    	SpriteBatch sb = new SpriteBatch(...);
    	while(Events.HasNext())
    	{
    		Events.GetNext().Render(sb);
    	}
    }
    
    public static class Events
    {
    	private static Queue<IRenderable> renderables = new Queue<IRenderable>();
    	
    	public static void Queue(IRenderable renderable)
    	{
    		renderables.Enqueue(message);
    	}
    	
    	public static IRenderable GetNext()
    	{
    		return renderables.Dequeue();
    	}
    	
    	public static bool HasNext()
    	{
    		return renderables.Count > 0;
    	}
    }
    
    public interface IRenderable
    {
    	void Render(SpriteBatch sb);
    }
    
    public class Message : IRenderable
    {
    	public string Text {get; set;}
    	
    	public void Render(SpriteBatch sb)
    	{
    		// ... render code
    	}
    }
    
    public class ChuckNorris : IRenderable
    {
    	public void Render(SpriteBatch sb)
    	{
    		// render code
    	}
    }
