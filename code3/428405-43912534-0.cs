    public static class Util {
    	public static string Switch(string value, params string[] nameValues) {
    		for (int x = 0; x < nameValues.Length; x += 2) {
    			if (nameValues[x] == value) {
    				return nameValues[x + 1];
    			}
    		}
    		return string.Empty;
    	}
    }
