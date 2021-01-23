       [TestMethod]
        public void DisplayCustomerTest_FindsCorrectViewName()
        {
            var expected = "DisplayCustomer";
         
            var obj = new CustomerController();
            var cContext = new ControllerContext();
            cContext.RouteData.Values.Add("action", expected);
            cContext.RouteData.Values.Add("controller", "Customer");
            var actionResult = obj.DisplayCustomer(new Customer());
            //not necessary but helpful
            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
            //down cast
            var vResult = actionResult as ViewResult;
            try // the view name is populated early, and we don't care about what else it does
            {
                vResult.ExecuteResult(cContext);
            }
            catch (NotImplementedException) {} //catch the most specific error type you can
            Assert.AreEqual(expected, vResult.ViewName);
            
        }
