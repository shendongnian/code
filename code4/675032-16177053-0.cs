    object[][] testCases = new[] {
        // test case 1
        new object[] {
            "val1",
            new[] { "test11", "test12" }
        },
        // test case 2
        new object[] {
            "val2",
            new[] { "test21", "test22" }
        },
        // test case 3
        new object[] {
            "val3",
            new[] { "test31", "test32", "test33", "test34" }
        }
    };
    [Test]
    [TestCaseSource("testCases")]
    public void SomeTest(string param1, string[] param2)
    {
        ...
    }
