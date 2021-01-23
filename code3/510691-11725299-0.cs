	using System;
	
	namespace StringMatching
	{
		/// <summary>
		/// A class to extend the string type with a method to get Levenshtein Edit Distance.
		/// </summary>
		public static class LevenshteinDistanceStringExtension
		{
			/// <summary>
			/// Get the Levenshtein Edit Distance.
			/// </summary>
			/// <param name="strA">The current string.</param>
			/// <param name="strB">The string to determine the distance from.</param>
			/// <returns>The Levenshtein Edit Distance.</returns>
			public static int GetLevenshteinDistance(this string strA, string strB)
			{
				if (string.IsNullOrEmpty(strA) && string.IsNullOrEmpty(strB))
					return 0;
	
				if (string.IsNullOrEmpty(strA))
					return strB.Length;
	
				if (string.IsNullOrEmpty(strB))
					return strA.Length;
	
				int[,] deltas; // matrix
				int lengthA;
				int lengthB;
				int indexA;
				int indexB;
				char charA;
				char charB;
				int cost; // cost
	
				// Step 1
				lengthA = strA.Length;
				lengthB = strB.Length;
	
				deltas = new int[lengthA + 1, lengthB + 1];
	
				// Step 2
				for (indexA = 0; indexA <= lengthA; indexA++)
				{
					deltas[indexA, 0] = indexA;
				}
	
				for (indexB = 0; indexB <= lengthB; indexB++)
				{
					deltas[0, indexB] = indexB;
				}
	
				// Step 3
				for (indexA = 1; indexA <= lengthA; indexA++)
				{
					charA = strA[indexA - 1];
	
					// Step 4
					for (indexB = 1; indexB <= lengthB; indexB++)
					{
						charB = strB[indexB - 1];
	
						// Step 5
						if (charA == charB)
						{
							cost = 0;
						}
						else
						{
							cost = 1;
						}
	
						// Step 6
						deltas[indexA, indexB] = Math.Min(deltas[indexA - 1, indexB] + 1, Math.Min(deltas[indexA, indexB - 1] + 1, deltas[indexA - 1, indexB - 1] + cost));
					}
				}
	
				// Step 7
				return deltas[lengthA, lengthB];
			}
		}
	}
