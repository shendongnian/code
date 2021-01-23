        [TestMethod]
		public void TestMethod1()
		{
			Exception defaultException = new Exception("No real execption.");
			try
			{
				#region Setup
				#endregion
				#region Tests
				#endregion
			}
			catch (Exception exc)
			{ 
                /*if an Assert fails this catches its Exception so that it can be thrown 
                in the finally block*/
				defaultException = exc; 
			}
			finally
			{
				#region Cleanup
                //cleanup code goes here 
				if (!defaultException.Message.Equals("No real execption."))
				{
					throw defaultException;
				}
				#endregion
			}
		} 
