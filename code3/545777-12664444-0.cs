	public class KeyConverter {
                //All conversions are stored in this dictionary.
		private Dictionary<Keys, Keys> conversions = new Dictionary<Keys, Keys>();
		
		public KeyConverter() {
			//this conversion will convert every Ctrl+C signal into Ctrl+V
			conversions.Add(Keys.C | Keys.Control, Keys.V | Keys.Control);
		}
		public Keys Convert(Keys keys) {
			if (conversions.ContainsKey(keys))
				return conversions[keys];
			else
				return keys;  //return the input if no conversion is available
		}
	}
