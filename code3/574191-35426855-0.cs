    internal class Utils
    {
    	internal static PingReply Ping (IPAddress address, int timeout = 1000, int ttl = 64)
    	{
    			PingReply tpr = null;
    			var p = new Ping ();
    			try {
    
    				tpr = p.Send (address,
    					timeout,
    					Encoding.ASCII.GetBytes ("oooooooooooooooooooooooooooooooo"),
    					new PingOptions (ttl, true));
    
    			} catch (Exception ex) {
    				
    				tpr = null;
    
    			} finally {
    				if (p != null)
    					p.Dispose ();
    
    				p = null;
    			}
    
    			return tpr;
    		}
    
    		internal static List<PingReply> PingAddresses (List<IPAddress> addresses, int timeout = 1000, int ttl = 64)
    		{
    			var ret = addresses
    				.Select (p => Ping (p, timeout, ttl))
    				.Where (p => p != null)
    				.Where (p => p.Status == IPStatus.Success)
    				.Select (p => p).ToList ();
    			
    			return ret;
    		}
    
    		internal static Task PingAddressesAsync (List<IPAddress> addresses, Action<Task<List<PingReply>>> endOfPing, int timeout = 1000, int ttl = 64)
    		{
    			
    			return Task.Factory.StartNew<List<PingReply>> (() => Utils.PingAddresses (
    				addresses, timeout, ttl)).ContinueWith (t => endOfPing (t));
    			
    		}	
    }
