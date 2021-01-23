    namespace FooRequest
    {
        public interface IAllCapsChecker
        {
            bool IsAllCaps(string request);
        }
        public interface ILetterBChecker
        {
            bool IsContainingB(string request);
        }
        public class Verifier
        {
            private readonly IAllCapsChecker m_AllCapsChecker;
            private readonly ILetterBChecker m_LetterBChecker;
            public Verifier(IAllCapsChecker allCapsChecker, ILetterBChecker letterBChecker)
            {
                m_AllCapsChecker = allCapsChecker;
                m_LetterBChecker = letterBChecker;
            }
            public bool IsValid(string request)
            {
                return (!m_AllCapsChecker.IsAllCaps(request) && !m_LetterBChecker.IsContainingB(request));
            }
        }
        [TestClass]
        public class IsValid
        {
            [TestMethod]
            public void ShouldReturnFalseForInvalidStringBecauseContainsB()
            {
                var allCapsMock = new Mock<IAllCapsChecker>();
                allCapsMock.Setup(checker => checker.IsAllCaps("example")).Returns(true);
                var letterBChecker = new Mock<ILetterBChecker>();
                letterBChecker.Setup(checker => checker.IsContainingB("example")).Returns(true);
                var verifier = new Verifier(allCapsMock.Object, letterBChecker.Object);
                Assert.IsFalse(verifier.IsValid("example"));
            }
        }
    }
