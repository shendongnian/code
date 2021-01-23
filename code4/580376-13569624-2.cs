	class Cache {
		private HubClient _hubClient;
		private Dictionary<string, string> _pages;
		public Cache(HubClient hubClient)
		{
			_hubClient = hubClient;
			_pages = new Dictionary<string, string>();
		}
		public bool isPageNew( string key, string content ) {
			string current;
			if (_pages.TryGetValue(key, out current) && XElement.Equals(current, content)) {
				return false;
			}
			_pages[key] = content;
			_hubClient.SendToHub(); //Why have side effect here? :P
			return true;
		}
	}
	
