        [TestMethod]
        public void GetVariableMapKmlWrongParams()
        {
            FieldDataController controller = new FieldDataController();
            controller.ControllerContext =
            TestUtils.CreateMockSessionControllerContext().Object as ControllerContext;
            //param null
            ContentResult result = controller.GetVariableMapKml(null, null, "05/05/2001",
                                                                "02/10/2012", 100);
            var returnedObject = (Dictionary<string, object>)(new JavaScriptSerializer()).DeserializeObject(result.Content);
            Assert.IsTrue(returnedObject.ContainsKey("Error"));
        }
