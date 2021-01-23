    public interface ICageable {}
    public abstract class Animal {}
    public class Hippo : Animal, ICageable {}
    public class Tiger : Animal, ICageable {}
    public class Human : Animal, ICageable {}
    public class Ape : Animal {}
    ....
    List<ICageable> ZooAnimals = new List<ICageable>{hippo, tiger, human};
