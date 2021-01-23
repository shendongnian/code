	public interface IPaymentDetails : IEquatable<IPaymentDetails>
	{
		int Id { get; }
		string Status { get; }
	} 
	
	public class PaymentDetails : IPaymentDetails, IEquatable<IPaymentDetails>
	{
		public PaymentDetails()
		{
		}
		
		public PaymentDetails(IPaymentDetails paymentDetails)
		{
			Id = paymentDetails.Id;
			Status = paymentDetails.Status;
		}
		
		public static implicit operator PaymentDetails(PaymentDetailsRO paymentDetailsRO)
		{
			PaymentDetails paymentDetails = new PaymentDetails(paymentDetailsRO);
			return paymentDetails;
		}
	
		public override int GetHashCode()
		{
			return Id.GetHashCode() ^ Status.GetHashCode();
		}
		
		public bool Equals(IPaymentDetails other)
		{
			if (other == null)
			{
				return false;
			}
			
			if (this.Id == other.Id && this.Status == other.Status)
			{
				return true;
			}
			else
			{
				return false;
			}
	}
	
		public override bool Equals(Object obj)
		{
			if (obj == null)
			{
				return base.Equals(obj);
			}
	
			IPaymentDetails iPaymentDetailsobj = obj as IPaymentDetails;
			if (iPaymentDetailsobj == null)
			{
				return false;
			}
			else
			{
				return Equals(iPaymentDetailsobj);
			}
	} 
	
		public static bool operator == (PaymentDetails paymentDetails1, PaymentDetails paymentDetails2)
		{
			if ((object)paymentDetails1 == null || ((object)paymentDetails2) == null)
			{
				return Object.Equals(paymentDetails1, paymentDetails2);
			}
	
			return paymentDetails1.Equals(paymentDetails2);
		}
	
		public static bool operator != (PaymentDetails paymentDetails1, PaymentDetails paymentDetails2)
		{
			if (paymentDetails1 == null || paymentDetails2 == null)
			{
				return ! Object.Equals(paymentDetails1, paymentDetails2);
			}
	
			return ! (paymentDetails1.Equals(paymentDetails2));
		}
	
		public int Id { get; set; }
		public string Status { get; set; }
	} 
	
	public class PaymentDetailsRO : IPaymentDetails, IEquatable<IPaymentDetails>
	{
		public PaymentDetailsRO()
		{
		}
		
		public PaymentDetailsRO(IPaymentDetails paymentDetails)
		{
			Id = paymentDetails.Id;
			Status = paymentDetails.Status;
		}
	
		public static implicit operator PaymentDetailsRO(PaymentDetails paymentDetails)
		{
			PaymentDetailsRO paymentDetailsRO = new PaymentDetailsRO(paymentDetails);		
			return paymentDetailsRO;
		}
	
		public override int GetHashCode()
		{
			return Id.GetHashCode() ^ Status.GetHashCode();
		}
		
		public bool Equals(IPaymentDetails other)
		{
			if (other == null)
			{
				return false;
			}
			
			if (this.Id == other.Id && this.Status == other.Status)
			{
				return true;
			}
			else
			{
				return false;
			}
	}
	
		public override bool Equals(Object obj)
		{
			if (obj == null)
			{
				return base.Equals(obj);
			}
	
			IPaymentDetails iPaymentDetailsobj = obj as IPaymentDetails;
			if (iPaymentDetailsobj == null)
			{
				return false;
			}
			else
			{
				return Equals(iPaymentDetailsobj);
			}
	} 
	
		public static bool operator == (PaymentDetailsRO paymentDetailsRO1, PaymentDetailsRO paymentDetailsRO2)
		{
			if ((object)paymentDetailsRO1 == null || ((object)paymentDetailsRO2) == null)
			{
				return Object.Equals(paymentDetailsRO1, paymentDetailsRO2);
			}
	
			return paymentDetailsRO1.Equals(paymentDetailsRO2);
		}
	
		public static bool operator != (PaymentDetailsRO paymentDetailsRO1, PaymentDetailsRO paymentDetailsRO2)
		{
			if (paymentDetailsRO1 == null || paymentDetailsRO2 == null)
			{
				return ! Object.Equals(paymentDetailsRO1, paymentDetailsRO2);
			}
	
			return ! (paymentDetailsRO1.Equals(paymentDetailsRO2));
		}
	
		public int Id { get; private set; }
		public string Status { get; private set;}
	} 
	
	public class PaymentHelper
	{
		private PaymentDetails _paymentDetails;
	
		public PaymentDetailsRO MyPaymentDetails
		{
			get
			{
				return _paymentDetails;
			}
		}
	
		public PaymentHelper()
		{
			_paymentDetails = new PaymentDetails();
		}
	
		public void ModifyPaymentDetails(string someString)
		{
			// code to take the arguments and modify this._paymentDetails
		}
	}
