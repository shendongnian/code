    [TestClass]
    public class ScratchPadTest
    {
        private int CalculateShift(int listCount, int iterations)
        {
            if (listCount == 0)
            { 
                return 0;
            }
            return iterations % listCount;
        }
        private List<string> PerformShift(List<string> list, int iterations)
        {
            var myShiftCount = CalculateShift(list.Count, iterations);
            var myList = new List<string>();
            for (int index = 0; index < myShiftCount; index++)
            {
                myList.Add(list[(index + myShiftCount) % list.Count]);
            }
            return myList;
        }
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void ZeroIterationsReturns0()
        {
            Assert.AreEqual<int>(0, CalculateShift(0, 0));
        }
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void OneITerationReturnsOne_With_List_Size_Two()
        {
            Assert.AreEqual<int>(1, CalculateShift(2, 1));
        }
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void OneIterationReturns_Zero_With_ListSizeOne()
        {
            Assert.AreEqual<int>(0, CalculateShift(1, 1));            
        }
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Shifting_Two_Element_List_By_101_Reverses_Elements()
        {
            var myList = new List<string>() { "1", "2" };
            Assert.AreEqual<string>("2", PerformShift(myList, 101)[0]);
        }
    }
