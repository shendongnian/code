    [Fact]
    public void ShouldWork()
    {
        var _JobTaskMock = new JobTaskMock(_Scheduler);
        var o = _Scheduler.CreateColdObservable
            ( OnNext(100, "A")
            , OnNext(200, "B")
            , OnNext(300, "C")
            , OnNext(400, "D")
            , OnNext(500, "E")
            , OnNext(600, "F")
            );
        var actual = _Scheduler.Start(() =>
        {
            return o.SelectWithCancellation(_JobTaskMock.JobTask);
        }
        , created: 0
        , subscribed: 1
        , disposed: 1000
        );
        var expected = new[] { "A", "B", "D", "F" };
        _JobTaskMock.CancelCount.Should().Be(2);
        actual.Messages.Select(v=>v.Value.Value)
            .ShouldBeEquivalentTo(expected);
    }
