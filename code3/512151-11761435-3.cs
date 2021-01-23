	Console.WriteLine(TestType(new CompositionPlugin(), 
                typeof(CompositionPlugin))); //True
	Console.WriteLine(TestType(new CompositionPlugin(), 
                typeof(MyCompositionPlugin))); //False
	Console.WriteLine(TestType(new MyCompositionPlugin(), 
                typeof(CompositionPlugin))); //False
	Console.WriteLine(TestType(new MyCompositionPlugin(),
                typeof(MyCompositionPlugin))); //True
