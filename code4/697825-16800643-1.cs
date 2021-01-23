    namespace StackOverflowExample.Moq
    {
        public interface ISequenceGenerator
        {
            IEnumerable<int> GetSequence();
        }
    
        public class SequenceGenrator : ISequenceGenerator
        {
            public IEnumerable<int> GetSequence()
            {
                var list = new List<int>();
                for (var i = 0; i < 1000000; i++) // Large number of calls to dep
                {
                    list.Add(i);
                }
                return list;
            }
        }
    
        public interface ISomeInterface
        {
            void SomeMethod(int someValue);
        }
    
        public class ClassUnderTest
        {
            private readonly ISequenceGenerator _generator;
            private readonly ISomeInterface _dep;
    
            public ClassUnderTest(ISomeInterface dep, ISequenceGenerator generator)
            {
                _dep = dep;
                _generator = generator;
            }
    
            public void DoWork()
            {
                foreach (var i in _generator.GetSequence())
                {
                    _dep.SomeMethod(i);
                }
            }
        }
    
        [TestFixture]
        public class LargeSequence
        {
            [Test]
            public void SequenceGenerator_should_()
            {
                //arrange
                var generator = new SequenceGenrator();
    
                //act
                var list = generator.GetSequence();
    
                //assert
                list.Should().Not.Contain(-1);
                Executing.This(() => list.Single(i => i == 12345)).Should().NotThrow();
                //any other assertions
            }
    
            [Test]
            public void DoWork_should_perform_action_on_each_element_from_generator()
            {
                //arrange
                var items = new List<int> {1, 2, 3}; //can use autofixture to generate random lists
                var generator = Mock.Of<ISequenceGenerator>(g => g.GetSequence() == items);
                var mockSF = new Mock<ISomeInterface>();
    
                var classUnderTest = new ClassUnderTest(mockSF.Object, generator);
    
                //act
                classUnderTest.DoWork();
    
                //assert
                foreach (var item in items)
                {
                    mockSF.Verify(c=>c.SomeMethod(item), Times.Once());
                }
            }
        }
    }
