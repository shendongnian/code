    public static class ThreeDimensionalArrayExtensionMethods {
    	public static IEnumerable<ThreeDimensionalArrayExtension<T>> ConvertArray<T>(this T[,,] foos) {
    		for(var x = 0; x < foos.GetLength(0); x++) {
    			for (var y = 0; y < foos.GetLength(1); y++) {
    				for (var z = 0; z < foos.GetLength(2); z++) {
    					yield return new ThreeDimensionalArrayExtension<T> { X = x, Y = y , Z = z, Value = foos[x, y, z] };
    				}
    			}
    		}
    	}
    }
