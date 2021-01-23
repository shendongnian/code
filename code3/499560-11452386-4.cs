    public class PaymentApplicationService
    {
        public void PayForOrderWithGiftCoupons(PayForOrderWithGiftCouponsCommand command)
        {
            using (IUnitOfWork unitOfWork = UnitOfWorkFactory.Create())
            {
                Order order = _orderRepository.GetById(command.OrderId);
                List<GiftCoupon> coupons = new List<GiftCoupon>();
                foreach(Guid couponId in command.CouponIds)
                    coupons.Add(_giftCouponRepository.GetById(couponId));
                order.MakePaymentWithGiftCoupons(coupons);
                _orderRepository.Save(order);
                foreach(GiftCoupon coupon in coupons)
                    _giftCouponRepository.Save(coupon);
            }
        }
    }
    public class Order : IAggregateRoot
    {
        private readonly Guid _orderId;
        private readonly List<Payment> _payments = new List<Payment>();
        public Guid OrderId 
        {
            get { return _orderId;}
        }
        public void MakePaymentWithGiftCoupons(List<GiftCoupon> coupons)
        {
            foreach(GiftCoupon coupon in coupons)
            {
                if (!coupon.IsValid)
                    throw new Exception("Coupon is no longer valid");
                coupon.UseForPaymentOnOrder(this);
                _payments.Add(new GiftCouponPayment(Guid.NewGuid(), DateTime.Now, coupon));
            }
        }
    }
    public abstract class Payment : IEntity
    {
        private readonly Guid _paymentId;
        private readonly DateTime _paymentDate;
        public Guid PaymentId { get { return _paymentId; } }
        public DateTime PaymentDate { get { return _paymentDate; } }
        public abstract decimal Amount { get; }
        public Payment(Guid paymentId, DateTime paymentDate)
        {
            _paymentId = paymentId;
            _paymentDate = paymentDate;
        }
    }
    public class GiftCouponPayment : Payment
    {
        private readonly Guid _couponId;
        private readonly decimal _amount;
        public override decimal  Amount
        {
	        get { return _amount; }
        }
        public GiftCouponPayment(Guid paymentId, DateTime paymentDate, GiftCoupon coupon)
            : base(paymentId, paymentDate)
        {
            if (!coupon.IsValid)
                throw new Exception("Coupon is no longer valid");
            _couponId = coupon.GiftCouponId;
            _amount = coupon.Value;
        }
    }
    public class GiftCoupon : IAggregateRoot
    {
        private Guid _giftCouponId;
        private decimal _value;
        private DateTime _issuedDate;
        private Guid _orderIdUsedFor;
        private DateTime _usedDate;
        public Guid GiftCouponId
        {
            get { return _giftCouponId; }
        }
        public decimal Value
        {
            get { return _value; }
        }
        public DateTime IssuedDate
        {
            get { return _issuedDate; }
        }
        public bool IsValid
        {
            get { return (_usedDate == default(DateTime)); }
        }
        public void UseForPaymentOnOrder(Order order)
        {
            _usedDate = DateTime.Now;
            _orderIdUsedFor = order.OrderId;
        }
    }
