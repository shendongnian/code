	public struct CodePointIndex {
		public int Index;
		public bool Valid;
		public bool IsSurrogatePair;
		public static CodePointIndex Create(int index, bool valid, bool isSurrogatePair) {
			return new CodePointIndex {
				Index = index,
				Valid = valid,
				IsSurrogatePair = isSurrogatePair,
			};
		}
	}
