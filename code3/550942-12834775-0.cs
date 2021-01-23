		[TestMethod()]
		[DeploymentItem("IICMS.dll")]
		public void CheckNullableDateTimeTest_SqlDataReader_Valid()
		{
			MockRepository mocks = new MockRepository();
			SqlDataReader reader = mocks.DynamicMock<SqlDataReader>();
			IDataReader reader2 = reader;
			string column = "test";
			DateTime? expected = new DateTime(2,1,1);
			DateTime? actual;
			reader.Stub(r => r[column]).Return(invalidValue);
			reader.Stub(r => r[0]).Return(invalidValue);
			reader.Stub(r => r.FieldCount).Return(1);
			reader.Stub(r => r.GetName(0)).Return(column);
			reader2.Stub(r => r[column]).Return(invalidValue);
			reader2.Stub(r => r[0]).Return(invalidValue);
			reader2.Stub(r => r.FieldCount).Return(1);
			reader2.Stub(r => r.GetName(0)).Return(column);
			mocks.ReplayAll();
			actual = Utility_Accessor.CheckNullString(reader, column);
			Assert.AreEqual(expected, actual);
		}
