    var factory = A.Fake<IFactory> ();
    A.CallTo (() => factory.Create (A<string>.Ignored, A<string>.Ignored))
                  .ReturnsLazily ((string name, string data) => new Data (name, data));
    var module = new QuickModule (factory);
    var list = module.GetData ();
