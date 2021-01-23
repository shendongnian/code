        [TestMethod]
        public void WeekNumbers_CorrectFor_3000Years()
        {
            var weekNumbersMethod1 = WeekNumbers3000Years(DateManipulation.WeekNumber).ToList();
            var weekNumbersMethod2 = WeekNumbers3000Years(DateManipulation.WeekNumber2).ToList();
            CollectionAssert.AreEqual(weekNumbersMethod1, weekNumbersMethod2);
        }
        private IEnumerable<int> WeekNumbers3000Years(Func<DateTime, int> weekNumberCalculator)
        {
            var startDate = new DateTime(1,1,1);
            var endDate = new DateTime(3000, 12, 31);
            for(DateTime date = startDate; date < endDate; date = date.AddDays(1))
                yield return weekNumberCalculator(date);
        }
