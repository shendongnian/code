    public string[] Input = new[]{
                                        "R1, F1, F2, F3",
                                        "R2, F2, F4",
                                        "R3, F2",
                                        "R3, F2",
                                        "R4, F1, F2, F3, F4"
                                    };
    public class RecordOne {
    }
    public class RecordTwo {
    }
    public class RecordThree {
    }
    public class RecordFour {
    }
    public class BuilderFactory {
        public BuilderFactory() {
            Builders = new Dictionary<string, Func<IEnumerable<string>, object>>();
        }
        private Dictionary<string, Func<IEnumerable<string>, object>> Builders { get; set; }
        public void RegisterBuilder(string name, Func<IEnumerable<string>, object> builder) {
            Builders.Add(name, builder);
        }
        public Func<IEnumerable<string>, object> GetBuilder(string name) {
            return Builders[name];
        }
    }
    [TestMethod]
    public void LoadRecords() {
        var factory = new BuilderFactory();
        factory.RegisterBuilder("R1", BuildRecordOne);
        factory.RegisterBuilder("R2", BuildRecordTwo);
        factory.RegisterBuilder("R3", BuildRecordThree);
        factory.RegisterBuilder("R4", BuildRecordFour);
        var output = Input.Select(line => {
            var pieces = line.Split(',').Select(val => val.Trim());
            var builder = factory.GetBuilder(pieces.First());
            return builder(pieces.Skip(1));
        });
        Assert.IsTrue(new[] {typeof(RecordOne),
                             typeof(RecordTwo),
                             typeof(RecordThree),
                             typeof(RecordThree),
                             typeof(RecordFour)}.SequenceEqual(output.Select(rec => rec.GetType())));
    }
    private static RecordOne BuildRecordOne(IEnumerable<string> pieces) {
        return new RecordOne();
    }
    private static RecordTwo BuildRecordTwo(IEnumerable<string> pieces) {
        return new RecordTwo();
    }
    private static RecordThree BuildRecordThree(IEnumerable<string> pieces) {
       return new RecordThree();
    }
    private static RecordFour BuildRecordFour(IEnumerable<string> pieces) {
        return new RecordFour();
    }
