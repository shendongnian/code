    [TestClass]
        public class TestMethodParam
        {
            [TestMethod]
            public void TestMethod1()
            {
                var repairCarCalls = new List<string>();
                Mock<ICarService> carService = new Mock<ICarService>();
    
                var car = new Car
                {
                    Name = "1"
                };
    
                var car2 = new Car
                {
                    Name = "2"
                };
    
                carService.Setup(c => c.RepairCar(It.IsAny<Car>())).Callback<Car>(c => repairCarCalls.Add(c.Name));
    
                var carManager = new CarManager(carService.Object);
    
                //act
                carManager.Serve();
    
                //assert: 
                var expectedCalls = new[] { car.Name, car2.Name };
                CollectionAssert.AreEqual(expectedCalls, repairCarCalls);
            }
        }
