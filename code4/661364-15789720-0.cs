    var list = new []
				{
					new [] { 1, 2, 3 },
					new [] { 4, 5, 6 },
					new [] { 7, 8, 9 }
				};
    var maxX = list.Select(s => s.Skip(0).Take(1)).Max();
    var minY = list.Select(s => s.Skip(1).Take(1)).Min();
