     [Theory]
            [InlineData("http://localhost:12345/api/Cars/123", "GET", typeof(CarsController), "GetCars")]
            [InlineData("http://localhost:12345/api/Cars", "GET", typeof(CarsController), "GetCars")]
            public void Ensure_Correct_Controller_and_Action_Selected(string url,string method,
                                                        Type controllerType,string actionName) {
                //Arrange
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
    
                var controllerSelector = config.Services.GetHttpControllerSelector();
                var actionSelector = config.Services.GetActionSelector();
    
                var request = new HttpRequestMessage(new HttpMethod(method),url);
    
                config.EnsureInitialized();
               
                var routeData = config.Routes.GetRouteData(request);
                request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
                request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
                //Act
                var ctrlDescriptor = controllerSelector.SelectController(request);
                var ctrlContext = new HttpControllerContext(config, routeData, request)
                {
                    ControllerDescriptor = ctrlDescriptor
                };
                var actionDescriptor = actionSelector.SelectAction(ctrlContext);
                //Assert
                Assert.NotNull(ctrlDescriptor);
                Assert.Equal(controllerType, ctrlDescriptor.ControllerType);
                Assert.Equal(actionName, actionDescriptor.ActionName);
            }
        }
