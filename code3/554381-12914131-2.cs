    [TestClass]
    public class UnitTest1
    {
      [TestMethod]
      public void TestMethod1()
      {
        var mock = new Mock<INextPaymentCreator>();
        DateTime dt = DateTime.Now;
        var current = new RecurringProfile(mock.Object, dt, TimeSpan.FromDays(30));
        current.ActivateProfile();
        mock.Verify(c => c.CreateNextPayment(current), Times.Once());
      }
    }
    public class RecurringProfile
    {
      private readonly INextPaymentCreator _creator;
      private readonly DateTime _dueDate;
      private readonly TimeSpan _interval;
      public RecurringProfile(INextPaymentCreator creator, DateTime dueDate, TimeSpan interval)
      {
        _creator = creator;
        _dueDate = dueDate;
        _interval = interval;
      }
      public bool IsActive { get; private set; }
      public DateTime DueDate
      {
        get { return _dueDate; }
      }
      public TimeSpan Interval
      {
        get { return _interval; }
      }
      public RecurringProfile ActivateProfile()
      {
        this.IsActive = true;
        var next = this._creator.CreateNextPayment(this);
        return next;
      }
    }
    
    public interface INextPaymentCreator
    {
      RecurringProfile CreateNextPayment(RecurringProfile current);
    }
