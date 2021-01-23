		private string _foo;
		private string foo
		{
			get
			{
				if (_foo == null)
					foo = null;
				return _foo;
			}
			set
			{
				if (value == null)
					value = "Something";
				_foo = value;
			}
		}
		[TestMethod]
		public void Test()
		{
			Assert.AreEqual("Something", foo);
		}
