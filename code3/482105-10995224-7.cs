    static void RunTests()
    {
        const int iterations = 100000000;
        var timespanRun1 = ExecuteOneWayTest(iterations);
        var timespanRun2 = ExecuteAnotherWayTest(iterations);
        // Evaluate Results....
    }
