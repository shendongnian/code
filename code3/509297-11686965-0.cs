    public static class HandlerFactory {
    	private static Object factoryLock = new Object();
    	private static List<IHandler> handlers = null;
    
    	public static IHandler Gethandler(String type) {
    		if (handlers == null) {
    			lock (factoryLock) {
    				if (handlers == null) {
    					IEnumerable<Type> types = typeof(HandlerFactory).Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IHandler)));
    					handlers = types.Select(t => (IHandler)Activator.CreateInstance(t));
    				}
    			}
    		}
    		return handlers.Where(h => h.Type == type);
    	}
    }
    
    public interface IHandler {
    	String Type { get; }
    	Boolean IsValid(String data);
    }
