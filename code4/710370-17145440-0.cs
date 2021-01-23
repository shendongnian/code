    [TestClass]
    public class SomeClassTests
    {
        [TestMethod]
        public void UpdatePaymentStatus_PaymentIds_VerifyPaymentLogicGeneratePaymentStatus() {
            var mock = new Mock<IPaymentLogic>();
            var sut = new Sut();
            var idList = new List<int> {2, 3};
            sut.UpdatePaymentStatus(idList, mock.Object);
            mock.Verify(x => x.GeneratePaymentStatus(idList));
        }
    }
    public class Sut {
        public void UpdatePaymentStatus(IList<int> paymentIds, IPaymentLogic paymentLogic) {
            paymentLogic.GeneratePaymentStatus(paymentIds);
        }
    }
    public interface IPaymentLogic {
        void GeneratePaymentStatus(IList<int> paymentIds);
    }
