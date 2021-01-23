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
