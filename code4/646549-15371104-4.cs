	public static partial class TestClass {
		public static void TestDeepCopy(Piece[] pieces) {
			Piece[] newPieces=new Piece[24];
			newPieces=DeepCopy.ObjectExtensions.Copy(pieces);
			newPieces[0].isKing=true;
			newPieces[0].Value=3;
			newPieces[1].isKing=true;
			newPieces[1].taken=true;
			newPieces[1].Value=4;
			Console.WriteLine("=== newPieces ===");
			foreach(var x in newPieces)
				Console.WriteLine(
					"x.isKing={0}; x.isBlack={1}; x.Value={2}",
					x.isKing, x.isBlack, x.Value
					);
			Console.WriteLine();
			Console.WriteLine("=== pieces ===");
			foreach(var x in pieces)
				Console.WriteLine(
					"x.isKing={0}; x.isBlack={1}; x.Value={2}",
					x.isKing, x.isBlack, x.Value
					);
		}
		public static void StartTest() {
			var pieceA=new Piece(1, false, false, 1, 1, false);
			var pieceB=new Piece(2, true, false, 1, 1, false);
			var pieces=new[] { pieceA, pieceB };
			TestDeepCopy(pieces);
		}
	}
