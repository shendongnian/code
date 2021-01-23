	public enum EventType
	{
		// Your event types
	}
	
	public static class EventHub
	{
		static Dictionary<EventType, List<Delegate>> _eventHandlers;
		
		// Use this to fire events with input
		public static void Publish( EventType eventType, object data )
		{
			// Fire event handler if found
			if( _eventHandlers.ContainsKey( eventType ) )
			{
				_invokeHandlers( _eventHandlers[ eventType ], data );
			}
		}
		
		static void _invokeHandlers(List<Delegate> list, object data)
		{
			if( !(list != null && list.Count > 0) )
				return;
			
			foreach( var handler in list )
				handler.DynamicInvoke( data );
		}
		
		// Use this to register new "listeners"
		public static void Register( EventType eventType, Delegate handler )
		{
			// Init dictionary
			if( _eventHandlers == null )
				_eventHandlers = new Dictionary<EventType, List<Delegate>>();
			
			// Add handler
			if( _eventHandlers.ContainsKey( eventType ) )
				_eventHandlers[ eventType ].Add( handler );
			else
				_eventHandlers.Add( eventType, new List<Delegate> { handler });
		}
		
		// Use this to remove "listeners"
		public static void Dismiss( EventType eventType, Delegate handler )
		{
			// Nothing to remove
			if( _eventHandlers == null || _eventHandlers.Count == 0 )
				return;
			
			// Remove handler
			if( _eventHandlers.ContainsKey( eventType ) && _eventHandlers[ eventType ].Count > 0 )
				_eventHandlers[ eventType ].Remove( handler );
			
			// Remove Key if no handlers left
			if( _eventHandlers[ eventType ].Count == 0 )
				_eventHandlers.Remove( eventType );
		}
	}
