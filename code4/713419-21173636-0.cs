    IGrabSomeData grabSomeData_1 = Substitute.For<IGrabSomeData>();
    
    byte[] empty = { };
    grabSomeData_1.GrabThatData(Arg.Is<string>(x => string.Equals(x, "test1.xml")), out empty).Returns(x => { x[1] = new byte[] { 0, 1, 2 }; return true; });
    grabSomeData_1.GrabThatData(Arg.Is<string>(x => string.Equals(x, "test2.xml")), out empty).Returns(x => { x[1] = new byte[] { 0, 1, 2, 3, 4 }; return true; });
    grabSomeData_1.GrabThatData(Arg.Is<string>(x => string.Equals(x, "test3.xml")), out empty).Returns(x => { x[1] = new byte[] { 0, 1 }; return true; });
    
    byte[] test1 = {};
    var result1 = grabSomeData_1.GrabThatData("test1.xml", out test1);
    Assert.IsTrue(test1.Length == 2);
