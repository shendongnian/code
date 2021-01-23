	partial class SlidingPuzzle {
		void SetCursorToBottom() {
			var pos=posBottom;
			Console.SetCursorPosition(pos.Left, pos.Top);
		}
		void ShowOnEnd() {
			if(IsGameOver) {
				Console.WriteLine("- Game Over -");
				Console.WriteLine("You've reached the limitation of movement. ");
			}
			else {
				Console.WriteLine("- Game Completed -");
				Console.WriteLine("Congratulations! You've solved the puzzle. ");
			}
		}
		void ShowStatics() {
			var pos=posStatics;
			Console.SetCursorPosition(pos.Left, pos.Top);
			Console.Write("Score: {0}", score);
			Console.Write(SlidingPuzzle.indentation);
			Console.WriteLine("Moves: {0}", moves);
		}
		void ShowPrompt() {
			var pos=posPrompt;
			Console.SetCursorPosition(pos.Left, pos.Top);
			Console.WriteLine("Enter your move [←, ↑, →, ↓, Esc] ");
		}
		void ShowMatrix() {
			var pos=posMatrix;
			Console.SetCursorPosition(pos.Left, pos.Top);
			for(int m=lengths[0], i=0, n, j; m-->0; ++i)
				for(n=lengths[1], j=0; n-->0; ++j) {
					var value=this[i, j].ToString();
					if("0"==value) {
						value="\x20";
						var left=indentation.Length+Console.CursorLeft;
						pos=new Position(left, Console.CursorTop);
					}
					if(SlidingPuzzle.linesPerRow>0)
						Console.Write(SlidingPuzzle.indentation+value);
					if(0==n)
						for(var count=SlidingPuzzle.linesPerRow; count-->0; )
							Console.WriteLine("");
				}
			Console.SetCursorPosition(pos.Left, pos.Top);
		}
		void SetLayoutPosition() {
			posMatrix=new Position(0, 2);
			posPrompt=new Position(0, posMatrix.Top+lengths[0]*linesPerRow);
			posBottom=new Position(0, 1+posPrompt.Top);
			posStatics=new Position(0, 0);
		}
		Position posBottom, posMatrix, posStatics, posPrompt;
		static readonly int linesPerRow=2;
		static readonly String indentation=new String('\x20', 4);
	}
