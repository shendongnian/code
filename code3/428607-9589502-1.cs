    public static class EventBus
    {
        private static List<Delegate> actions;
    	public static void Register<T>(Action<T> callback) where T : IPresentationEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }
        public static void ClearCallbacks()
        {
            actions = null;
        }
        public static void Raise<T>(T args) where T : IPresentationEvent
        {
        	if (actions == null)
            {
               return;
            }
			foreach (var action in actions)
			{
				if (!(action is Action<T>))
				{
					continue;
				}
				((Action<T>)action).Invoke(args);
			}
        }
    }
