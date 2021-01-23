    public class ConcreteClassModel : BaseModel
    {
    ... rest of class
    public bool InersectsWith(ConcreteClassModel crm)
        {
            return !(this.StartDateDT > crm.EndDateDT || this.EndDateDT < crm.StartDateDT);
        }
    }
    [TestClass]
    public class ConcreteClassTest
    {
        [TestMethod]
        public void TestConcreteClass_IntersectsWith()
        {
            var sutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 02, 01), EndDateDT = new DateTime(2016, 02, 29) };
            var periodBeforeSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 01, 01), EndDateDT = new DateTime(2016, 01, 31) };
            var periodWithEndInsideSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 01, 10), EndDateDT = new DateTime(2016, 02, 10) };
            var periodSameAsSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 02, 01), EndDateDT = new DateTime(2016, 02, 29) };
            var periodWithEndDaySameAsStartDaySutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 01, 01), EndDateDT = new DateTime(2016, 02, 01) };
            var periodWithStartDaySameAsEndDaySutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 02, 29), EndDateDT = new DateTime(2016, 03, 31) };
            var periodEnclosingSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 01, 01), EndDateDT = new DateTime(2016, 03, 31) };
            var periodWithinSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 02, 010), EndDateDT = new DateTime(2016, 02, 20) };
            var periodWithStartInsideSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 02, 10), EndDateDT = new DateTime(2016, 03, 10) };
            var periodAfterSutPeriod = new ConcreteClassModel() { StartDateDT = new DateTime(2016, 03, 01), EndDateDT = new DateTime(2016, 03, 31) };
            Assert.IsFalse(sutPeriod.InersectsWith(periodBeforeSutPeriod), "sutPeriod.InersectsWith(periodBeforeSutPeriod) should be false");
            Assert.IsTrue(sutPeriod.InersectsWith(periodWithEndInsideSutPeriod), "sutPeriod.InersectsWith(periodEndInsideSutPeriod)should be true");
            Assert.IsTrue(sutPeriod.InersectsWith(periodSameAsSutPeriod), "sutPeriod.InersectsWith(periodSameAsSutPeriod) should be true");
            Assert.IsTrue(sutPeriod.InersectsWith(periodWithEndDaySameAsStartDaySutPeriod), "sutPeriod.InersectsWith(periodWithEndDaySameAsStartDaySutPeriod) should be true");
            Assert.IsTrue(sutPeriod.InersectsWith(periodWithStartDaySameAsEndDaySutPeriod), "sutPeriod.InersectsWith(periodWithStartDaySameAsEndDaySutPeriod) should be true");
            Assert.IsTrue(sutPeriod.InersectsWith(periodEnclosingSutPeriod), "sutPeriod.InersectsWith(periodEnclosingSutPeriod) should be true");
            Assert.IsTrue(sutPeriod.InersectsWith(periodWithinSutPeriod), "sutPeriod.InersectsWith(periodWithinSutPeriod) should be true");
            Assert.IsTrue(sutPeriod.InersectsWith(periodWithStartInsideSutPeriod), "sutPeriod.InersectsWith(periodStartInsideSutPeriod) should be true");
            Assert.IsFalse(sutPeriod.InersectsWith(periodAfterSutPeriod), "sutPeriod.InersectsWith(periodAfterSutPeriod) should be false");
        }
    }
