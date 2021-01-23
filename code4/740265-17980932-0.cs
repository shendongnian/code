    public class Button {
        public string Whatever { get; set; }
        public Button() {
            Whatever = "Hello, world!";
        }
    }
    public interface IAddButton {
        Button CreateButton();
    }
    public class ClassToMakeButtonFor1 {
        public static void RegisterMe() {
            ButtonFactory.Register(typeof(ClassToMakeButtonFor1), new ButtonFactory1());
        }
    }
    public class ButtonFactory1 : IAddButton {
        public Button CreateButton() {
            return new Button();
        }
    }
    public class ClassToMakeButtonFor2 {
        public static void RegisterMe() {
            ButtonFactory.Register(typeof(ClassToMakeButtonFor2), new ButtonFactory2());
        }
    }
    public class ButtonFactory2 : IAddButton {
        public Button CreateButton() {
            var b = new Button { Whatever = "Goodbye!" };
            return b;
        }
    }
    public static class ButtonFactory {
        private static Dictionary<Type, IAddButton> FactoryMap = new Dictionary<Type, IAddButton>();
        public static void Register(Type type, IAddButton factoryClass) {
            FactoryMap[type] = factoryClass;
        }
        public static Button MakeMeAButton<T>() where T : class {
            return FactoryMap[typeof(T)].CreateButton();
        }
    }
    internal class Program {
        private static void Main(string[] args) {
            ClassToMakeButtonFor1.RegisterMe();
            ClassToMakeButtonFor2.RegisterMe();
            Button b = ButtonFactory.MakeMeAButton<ClassToMakeButtonFor1>();
            Console.WriteLine(b.Whatever);
            b = ButtonFactory.MakeMeAButton<ClassToMakeButtonFor2>();
            Console.WriteLine(b.Whatever);
            Console.ReadLine();
        }
    }
