    using NUnit.Framework;
    using Rhino.Mocks;
    using System;
    using System.Threading.Tasks;
    namespace StackOverflow_namespace
    {
        public interface IDateTime
        {
            DateTime Now();
        }
        public class DateTimeAdapter : IDateTime
        {
            public DateTime Now() { return DateTime.Now; }
        }
        public class Waiter
        {
            public static void WaitAnHour(IDateTime time)
            {
                //Incredibly wasteful - just to illustrate the point
                DateTime start = time.Now();
                DateTime end = start + TimeSpan.FromHours(1);
                while (end < time.Now()) ;
            }
        }
    
        [TestFixture]
        class StackOverflow
        {
            [Test]
            public void TestingTimeout()
            {
                DateTime testtime = DateTime.Now;
                var time = MockRepository.GenerateMock<IDateTime>();
                time.Stub(x => x.Now()).Do(new Func<DateTime>(() => { return testtime; }));
                var task = Task.Run(() => Waiter.WaitAnHour(time));
                Assert.IsFalse(task.IsCompleted, "Just Started");
                testtime = testtime.AddMinutes(60);
                task.Wait();
                Assert.IsTrue(task.IsCompleted, "60 Minutes Later");
            }
        
        }
    }
