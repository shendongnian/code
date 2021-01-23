      [TestMethod]
        public void DoSomethingInDB_SendOperationConfirmationToTheUI()
        {... var expected = "Operation failed";         
            var target = controller.A_Action_In_Controller(obj1.Id);
            
            Assert.AreEqual(expected, target.Data);
