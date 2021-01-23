    public interface IDatabaseProvider {
        IEnumerable<Car> GetCars();
    }
    public interface IFileStorage {
        string ReadText(string filepath);
        void SaveText(string filepath, string content);
    }
    public class MyClass {
        private readonly IDatabaseProvider dataProvider;
        private readonly IFileStorage storage;
        public MyClass(IDatabaseProvider dataProvider, IFileStorage storage) {
            this.dataProvider = dataProvider;
            this.storage = storage;
        }
        public void GenerateCarDetailsFile(IList<int> carIds, string location) {
            var cars = dataProvider.GetCars().Query<Car>().Where(x => carIds.Contains(x.Id));
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Make, Model, Year");
    
            foreach(var car in cars) {
                builder.WriteLine("{0},{1},{2}", car.Make, car.Model, car.Year);
            }
    
            storage.SaveText(location, builder.ToString());
        }
    }
    [Test]
    public void GenerateCarDetailsSavesFile() {
        // Arrange
        var databaseReturnValue = new List<Car> { new Car() { Make = "ma", Model = "mo", Year = 1900 };
        var location = "testpath.ext";
        var ids = new List<int> { 1, 3, 6 };
        var expectedOutput = "Make, Model, Year\r\nma,mo,1900";
        var database = MockRepository.GenerateMock<IDatabaseProvider>();
        var storage = MockRepository.GenerateMock<IFileStorage>();
        database
           .Stub(m => m.GetCars())
           .Return(databaseReturnValue);
        storage
           .Expect(m => m.SaveText(Arg<string>.Is.Equal(location),
                                   Arg<string>.Is.Equal(expectedOutput)));
        MyClass testee = new MyClass(database, storage);
        // Act
        testee.GenerateCarDetailsFile(ids, location);
        // Assert
        storage.VerifyAllExpectations();
    }
