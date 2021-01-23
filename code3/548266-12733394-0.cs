    [TestFixture]
    public class TravisSerialisationTest
    {
        [Test]
        public void GetPropertyValueTest()
        {
            var volvo = "Volvo";
            var viewModel = new ViewModel() { Car = volvo };
            var field = viewModel.GetField(() => viewModel.Car);
            Assert.AreEqual(volvo,field);
        }
    }
    
    public class ViewModel : BaseClass
    {
        public string Car { get; set; }
    }
    
    public abstract class BaseClass
    {
        public T GetField<T>(Expression<Func<T>> propertyExpression )
        {
            return propertyExpression.Compile().Invoke();
        }
    }
