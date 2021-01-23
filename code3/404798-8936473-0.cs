            [TestMethod]
            public void write_should_validate_model()
            {
                controller.ModelState.AddModelError("Title", "Empty"); //These values don't really matter
                var actionResult = controller.Write(new PostInputViewModel()) as ViewResult;
                
                //Assert that the correct view was returned i.e. Not Home/Index
                //Assert that a new post has not been added to your Mock Repository                
            }
