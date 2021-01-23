        [Fact]
        public void Foo()
        {
            var sched = new TestScheduler();
            var o = sched.CreateHotObservable
                ( OnNext(100, 10)
                , OnNext(200, 20)
                , OnNext(300, 30)
                , OnNext(400, 40)
                );
            var actual = sched.Start(() => {
                return o.Select(i=>i+1);
            }
            , created: 0
            , subscribed:1
            , disposed:500
            );
            var expected = new [] 
                { OnNext(100, 11)
                , OnNext(200, 21)
                , OnNext(300, 31)
                , OnNext(400, 41)
                };
            actual.Messages.ShouldBeEquivalentTo(expected);
        }
