  		private static DateTime _expiry = DateTime.MinValue;
		private static string _current = "0";
		
		public string CurrentNumber()
		{
		    if (_expiry < DateTime.Now)
			{
				_expiry = DateTime.Now.AddSeconds(5);
				_current = Get8Digits();
			}
			
			return _current;
		}
