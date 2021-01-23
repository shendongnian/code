		public static void ClearAspNetCache(HttpContext context) {
			foreach (DictionaryEntry entry in context.Cache) {
				context.Cache.Remove((string)entry.Key);
			}
		}
