    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void Polymorphic_objects_should_deserialize()
        {
            var database = MongoDatabase.Create("connection_string");
            var collection = database.GetCollection("vehicles");
            var car = new Car
            {
                wheels = new List<Wheel>
                           {
                               new WheelA {propA = 123},
                               new WheelB {propB = 456}
                           }
            };
            collection.Insert(car);
            var fetched = collection.AsQueryable<Car>()
                            .SingleOrDefault(x => x.Id == car.Id);
            Assert.IsNotNull(fetched.wheels);
            Assert.AreEqual(2, fetched.wheels.Count);
            Assert.IsInstanceOfType(fetched.wheels[0], typeof(WheelA));
            Assert.IsInstanceOfType(fetched.wheels[1], typeof(WheelB));
            Assert.AreEqual(123, (fetched.wheels[0] as WheelA).propA);
            Assert.AreEqual(456, (fetched.wheels[1] as WheelB).propB);
        }
    }
