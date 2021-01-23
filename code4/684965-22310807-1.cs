    [TestClass]
    public class UnitTest1
    {
        #region TestHelpers
        private ITnEntry MakeEntry(string ticker)
        {
            return new TnEntry {Ticker = ticker, List = new Ticket()};
        }
        #endregion
        [TestMethod]
        public void IsValidEntry_WithValidValues_ReturnsTrue()
        {
            // ARRANGE
            var target = new EntryValidator();
            var selectedEntry = MakeEntry("BOL");
            // ACT
            bool actual = target.IsValidEntry(selectedEntry, selectedEntry.Ticker);
            // ASSERT
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void IsValidEntry_WithInValidTicker_ReturnsFalse()
        {
            // ARRANGE
            var target = new EntryValidator();
            var selectedEntry = MakeEntry("");
            // ACT
            bool actual = target.IsValidEntry(selectedEntry, selectedEntry.Ticker);
            // ASSERT
            Assert.IsFalse(actual);
        }
        [TestMethod]        
        public void IsValidEntry_WithInvalidTicker_RaisesEvent()
        {
            // ARRANGE
            // generate a dynamic mock which will stub all virtual methods
            var target = Rhino.Mocks.MockRepository.GenerateMock<EntryValidator>();
            var selectedEntry = MakeEntry("");
            // ACT
            bool actual = target.IsValidEntry(selectedEntry, selectedEntry.Ticker);
            // ASSERT
            // assert that RaiseInvalidEntryEvent was called
            target.AssertWasCalled(x => x.RaiseInvalidEntryEvent(Arg<ITnEntry>.Is.Anything));
        }
        [TestMethod]
        public void RaiseInvalidEntryEvent_WithValidHandler_CallsDelegate()
        {
            // ARRANGE
            var target = new EntryValidator();
            var selectedEntry = MakeEntry("");
            bool delegateCalled = false;
            // attach a handler to set delegateCalled to true
            target.OnInvalidEntry += delegate 
            {
                delegateCalled = true;
            };
            
            // ACT
            target.IsValidEntry(selectedEntry, selectedEntry.Ticker);
            // ASSERT
            Assert.IsTrue(delegateCalled);
        }
    }
