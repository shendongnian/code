    [TestClass]
    public sealed class TimerExTest {
        [TestMethod]
        public void Delayed_actions_should_be_scheduled_correctly() {
            var timer = new MockTimer();
            var i = 0;
            var action = new DelayedAction(0, () => ++i);
            timer.DoThings(new[] {action, action});
            Assert.AreEqual(0, i);
            timer.OnTick();
            Assert.AreEqual(1, i);
            timer.OnTick();
            Assert.AreEqual(2, i);
            timer.OnTick();
            Assert.AreEqual(2, i);
        }
    }
