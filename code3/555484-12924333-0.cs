        [Fact]
        public void Test_Ref()
        {
            var barMock = MockRepository.GenerateMock<IDoSomething>();
            Composer composer = new Composer(barMock);
            int number = 12;
            composer.addStuff(0, number);
            barMock.AssertWasCalled(x => x.Add(0, ref number), 
                y=>y.IgnoreArguments().Repeat.Times(1));
        }
        public class Composer
        {
            private IDoSomething dosomething;
            public Composer(IDoSomething doSomething)
            {
                this.dosomething = dosomething;
            }
            
            public void addStuff(int id, int value)
            {
                dosomething.Add(id, ref value);
            }
        }
        public interface IDoSomething
        {
            void Add(int id, ref int value);
        }
