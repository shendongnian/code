    public class Enrolments : IEnumerable<IEnrolment>
    {
        private List<IEnrolment> list = new List<IEnrolment>();
        private int currentIndex;
        public IEnrolment GetNextEnrolment()
        {
            currentIndex = (currentIndex + 1) % list.Count;
            return list[currentIndex];
        }
        //TODO implementations of Add and GetEnumerator
    }
