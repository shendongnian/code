	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Drawing;
	using System.Diagnostics;
	namespace ConsoleApplication1
	{
		class Program
		{
			public const double MillisecondsBetweenMoves = (double)100;
			public const double DistancePerSecond = (double)10;
			static void Main(string[] args)
			{
				Point ptStart = new Point(0, 0);
				Point ptStop = new Point(70, 15);
				int deltaX = ptStop.X - ptStart.X;
				int deltaY = ptStop.Y - ptStart.Y;
				double DistanceToTravel = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
				Console.Clear();
				Console.SetCursorPosition(ptStart.X, ptStart.Y);
				Console.Write("a");
				Console.SetCursorPosition(ptStop.X, ptStop.Y);
				Console.Write("b");
				double TimeRequiredInMilliseconds = DistanceToTravel / DistancePerSecond * (double)1000;
				Stopwatch SW = new Stopwatch();
				SW.Start();
				while (SW.ElapsedMilliseconds < TimeRequiredInMilliseconds)
				{
					System.Threading.Thread.Sleep((int)MillisecondsBetweenMoves);
					Point position = new Point(
						ptStart.X + (int)((double)SW.ElapsedMilliseconds / TimeRequiredInMilliseconds * (double)deltaX),
						ptStart.Y + (int)((double)SW.ElapsedMilliseconds / TimeRequiredInMilliseconds * (double)deltaY)
						);
					Console.Clear();
					Console.SetCursorPosition(ptStart.X, ptStart.Y);
					Console.Write("a");
					Console.SetCursorPosition(ptStop.X, ptStop.Y);
					Console.Write("b");
					Console.SetCursorPosition(position.X, position.Y);
					Console.Write("X");
				}
				Console.Clear();
				Console.SetCursorPosition(ptStart.X, ptStart.Y);
				Console.Write("a");
				Console.SetCursorPosition(ptStop.X, ptStop.Y);
				Console.Write("b");
				Console.SetCursorPosition(ptStop.X, ptStop.Y);
				Console.Write("X");
				Console.ReadLine();
			}
		}
	}
