    var mock = new Mock<MyClass>();
    int callsCount = 0;
    mock
        .Setup(m => m.MyFunc(It.IsAny<int>(), It.IsAny<MyCallback>()))
        .Callback<int, MyCallback>(
            (i, callback) => 
            {
                if (callsCount++ == 0) callback("Some string");
                else mock.Raise(m => m.SomeEvent += null, EventArgs.Empty);
            });
