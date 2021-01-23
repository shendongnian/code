    public bool UpdateSomething(Something something)
    		{
    			U23.RuntimeContext.Current.TTSBegin();
    			try
    			{
    				if (something.Count == 0)
    				{
    					something.Delete();
    				}
    				something.Update();
    				U23.RuntimeContext.Current.TTSCommit();
    				return true;
    			}
    			catch
    			{
    				U23.RuntimeContext.Current.TTSAbort();
    				return false;
    			}
    		}
