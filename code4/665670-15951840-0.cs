    public interface IMyDependency {
        Dictionary<string, object> Outputs { get; }
    }
    // test...
    var dictionary = new Dictionary<string, string>{{"key", "value"}};
    var dependency = new Mock<IMyDependency>();
    dependency.SetupGet(d => d.Outputs).Returns(dictionary);
