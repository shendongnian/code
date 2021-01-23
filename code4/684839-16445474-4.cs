    public static class ThreeDimensionalArrayExtensionMethods {
    	public static IEnumerable<ThreeDimensionalArrayExtension<X>> ConvertArray(this X[] foos) {
    		for(var x = 0; x < foos.Count(); x++) {
    			for (var y = 0; y < foos[x].Count(); y++) {
    				for (var z = 0; z < foos[x][y].Count(); z++) {
    					yield return new ThreeDimensionalArrayExtension<T> { X = x, Y = y , Z = z, Value = foos[x][y][z] };
    				}
    			}
    		}
    	}
    }
