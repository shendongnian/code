     [Test, TestCaseSource("MyCaseSource")]
     public void MyMehthod(string Root, string Path, string Route, string Param, string Expected)
     {
       var result = SetupRouteResponse(Root, Path, Route, "MatchIt");
       Assert.AreEqual(Expected, (string)result.Context.Parameters[Param]);
     }
     static object[] MyCaseSource=
     {
        new object[] { "","/123",MyStatic.DoThis().And().GetString("ABC"), "id","123" },
     };
