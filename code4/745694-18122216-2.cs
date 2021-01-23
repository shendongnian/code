        public enum ABigEnum
        {
            A,
            B,
            C,
            D
        }
        [Datapoint]
        public Tuple<ABigEnum, bool>[] TestValues = new[]
                           {
                               new Tuple<ABigEnum, bool>(ABigEnum.A, false), new Tuple<ABigEnum, bool>(ABigEnum.B, false),
                               new Tuple<ABigEnum, bool>(ABigEnum.C, false), new Tuple<ABigEnum, bool>(ABigEnum.D, true)
                           };
        [Theory]
        public void Test(Tuple<ABigEnum,bool> data)
        {
            //generate someValue based upon enumValue    
            Assert.That(data.Item1, Is.EqualTo(data.Item2), "an amazing assertion message");
        }
