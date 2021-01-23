      [TestMethod]
      [DeploymentItem("C:/Sheets/DataSheet.xlsx")]
      [DataSource("MyExcelDataSource")]
      public void ChangePasswordTest()
      {
 
         int a = Convert.ToInt32(TestContext.DataRow[0]); //(int)Column.UserId
         int b = Convert.ToInt32(TestContext.DataRow[1]);
         int expectedResult = Convert.ToInt32(TestContext.DataRow[2]);
 
         MyClass myObj = new MyClass(1, "P@ssw0rd");
         int actualResult = myObj.GetAdditionResult(a, b);
         Assert.AreEqual<int>(expectedResult, actualResult, "The addition result is incorrect.");
 
      }
 
 
