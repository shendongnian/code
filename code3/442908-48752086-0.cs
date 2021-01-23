		public static bool PropertyExists(dynamic obj, string name) {
			if (obj == null) return false;
			if (obj is IDictionary<string, object> dict) {
				return dict.ContainsKey(name);
			}
			return obj.GetType().GetProperty(name) != null;
		}
