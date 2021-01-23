    class Sample {
        //code here that will meet the requirements of T
        //(eg. implement IComparable<T>, etc.)
    }
    [TestFixture]
    class Tests {
        [Test]
        public void DoSomething() {
            var sample1 = new Sample();
            var sample2 = new Sample();
            Sample[] result = DoSomething<Sample>(sample1, sample2);
            
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(result[0], sample1);
            Assert.AreEqual(result[1], sample2);
        }
    }
