StringCodePointExtensions.cs
	public static class StringCodePointExtensions {
		const char ReplacementCharacter = '\ufffd';
		public static IEnumerable<CodePointIndex> CodePointIndexes(this string s) {
			for (int i = 0; i < s.Length; i++) {
				if (char.IsHighSurrogate(s, i)) {
					if (i + 1 < s.Length && char.IsLowSurrogate(s, i + 1)) {
						yield return CodePointIndex.Create(i, true, true);
						i++;
						continue;
					} else {
						// High surrogate without low surrogate
						yield return CodePointIndex.Create(i, false, false);
						continue;
					}
				} else if (char.IsLowSurrogate(s, i)) {
					// Low surrogate without high surrogate
					yield return CodePointIndex.Create(i, false, false);
					continue;
				}
				yield return CodePointIndex.Create(i, true, false);
			}
		}
		public static IEnumerable<int> CodePointInts(this string s) {
			return s
				.CodePointIndexes()
				.Select(
				cpi => {
					if (cpi.Valid) {
						return char.ConvertToUtf32(s, cpi.Index);
					} else {
						return (int)ReplacementCharacter;
					}
				});
		}
	}
