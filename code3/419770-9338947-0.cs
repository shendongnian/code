        public class Foo {
    		private string _paymentMethod = "~~unspecified~~"; 
     		public string PaymentMethod
    		{
    			get    
    			{
    				return _paymentMethod;
    			}
    			set
    			{
    				if (string.IsNullOrWhiteSpace(value))
    					_paymentMethod = "~~unspecified~~";
    				else _paymentMethod = value;
    			}
    		}
    }
