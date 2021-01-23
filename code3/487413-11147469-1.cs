	var outputs = Enumerable.Repeat(0, 3).Select(_ => new Subject<char>()).ToArray();											  														  
													  
	outputs[0].Delay(TimeSpan.FromSeconds(2)).Subscribe(x => Console.WriteLine("hi: {0}", x));
	outputs[1].Delay(TimeSpan.FromSeconds(1)).Subscribe(x => Console.WriteLine("ho: {0}", x));
	outputs[2].Subscribe(x => Console.WriteLine("he: {0}", x));
