	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	class Program {
		static void Main(String[] args) {
			(new SlidingPuzzle(new[,] { 
				{ 3, 0, 8 }, 
				{ 6, 4, 7 }, 
				{ 2, 1, 5 }, 
				})).Run();
		}
	}
	public partial struct Position {
		public Position(int left, int top) {
			Left=left;
			Top=top;
		}
		public int Left, Top;
	}
	public partial class SlidingPuzzle {
		public void Run() {
			for(bool initialized=false, quit=false; ; ) {
				if(!initialized) {
					Reset();
					Console.Clear();
					ShowPrompt();
					initialized=true;
				}
				ShowStatics();
				ShowMatrix();
				if(quit||IsGameOver||IsFinished) {
					SetCursorToBottom();
					if(!quit)
						ShowOnEnd();
					if(!(quit=IsExit)) {
						initialized=false;
						continue;
					}
					break;
				}
				var keyInput=Console.ReadKey(true).Key;
				if(ConsoleKey.Escape==keyInput)
					quit=true;
				else if(ConsoleKey.LeftArrow==keyInput)
					Move(new[] { +0, +1 });
				else if(ConsoleKey.UpArrow==keyInput)
					Move(new[] { +1, +0 });
				else if(ConsoleKey.RightArrow==keyInput)
					Move(new[] { +0, -1 });
				else if(ConsoleKey.DownArrow==keyInput)
					Move(new[] { -1, +0 });
			}
		}
		void ReadOnExit() {
			Console.WriteLine("Press any key to exit ... ");
			Console.ReadKey(true);
		}
		bool IsExit {
			get {
				Console.WriteLine("Try again? (Y/N)");
				var quit=ConsoleKey.Y!=Console.ReadKey(true).Key;
				if(quit)
					ReadOnExit();
				return quit;
			}
		}
	}
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
	partial class SlidingPuzzle {
		void Reset() {
			Array.Copy(initial, mutable, initial.Length);
			current=IndexOf(0);
			moves=0;
			score=0;
		}
		void Move(int[] offset) {
			var indices=new int[lengths.Length];
			var i=0;
			for(i=indices.Length; i-->0; indices[i]=current[i]+offset[i])
				;
			for(i=indices.Length; i-->0; )
				if(0>indices[i]||indices[i]>lengths[i]-1)
					break;
			if(i<0) {
				var value=this[current];
				this[current]=this[indices];
				this[indices]=value;
				current=indices;
				++moves;
			}
		}
		int[] IndexOf(object value) {
			for(int m=lengths[0], i=0, n, j; m-->0; ++i)
				for(n=lengths[1], j=0; n-->0; ++j)
					if(this[i, j].ToString()==value.ToString())
						return new[] { i, j };
			return SlidingPuzzle.emptyArray;
		}
		object this[params int[] indices] {
			set {
				mutable.SetValue(value, indices);
			}
			get {
				return mutable.GetValue(indices);
			}
		}
		bool IsFinished {
			get {
				for(int m=lengths[0], i=0, n, j; m-->0; ++i)
					for(n=lengths[1], j=0; n-->0; ++j)
						if(this[i, j].ToString()!=(1+i*lengths[1]+j).ToString())
							if(0!=m||0!=n)
								return false;
				return true;
			}
		}
		bool IsGameOver {
			get {
				return !(maxMoves!=moves||IsFinished);
			}
		}
		public SlidingPuzzle(Array original) {
			var elementType=original.GetType().GetElementType();
			lengths=new int[original.Rank];
			for(var i=original.Rank; i-->0; lengths[i]=original.GetLength(i))
				;
			initial=Array.CreateInstance(elementType, lengths);
			mutable=Array.CreateInstance(elementType, lengths);
			Array.Copy(original, initial, original.Length);
			SetLayoutPosition();
		}
		int[] current;
		Array mutable;
		readonly int[] lengths;
		readonly Array initial;
		int score, moves, maxMoves=25;
		static readonly int[] emptyArray=new int[] { };
	}
