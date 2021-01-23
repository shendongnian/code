    public class SelectWithCancelationSpec : ReactiveTest
    {
        TestScheduler _Scheduler = new TestScheduler();
        [Fact]
        public void ShouldWork()
        {
            var o = _Scheduler.CreateColdObservable
                ( OnNext(100, "A")
                , OnNext(200, "B")
                , OnNext(300, "C")
                , OnNext(400, "D")
                , OnNext(500, "E")
                , OnNext(600, "F")
                );
            int cancelCount = 0;
            var job = _Scheduler.AsyncSelectorFactory<string,string>
                ( 1000
                , 10
                , async ( token, input, ticker ) => { 
                    if ( input == "C" || input == "E" )
                    {
                        await ticker.TakeWhile(v => !token.IsCancellationRequested);
                        cancelCount++;
                    }
                    return input;
                });
            var actual = _Scheduler.Start(() =>
            {
                return o.SelectWithCancellation(job);
            }
            , created: 0
            , subscribed: 1
            , disposed: 1000
            );
            var expected = new[] { "A", "B", "D", "F" };
            cancelCount.Should().Be(2);
            actual.Messages.Select(v=>v.Value.Value)
                .ShouldBeEquivalentTo(expected);
        }
    }
