    public class PersonTests
    {
        [Test, TestCaseSource("myConstructorsForMale")]
        public void CheckMale(Person p)
        {
            Assert.That(p.IsMale);
        }
        static Person[] myConstructorsForMale = 
                     {
                         new Person("John"),
                         new Person{IsMale=true},
                         new Person("Doe")
                     };
    }
