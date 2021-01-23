    public abstract class BaseClass {
        static readonly Dictionary<Type, Delegate>
                m_factories = new Dictionary<Type, Delegate> { };
        public static BaseClass CreateInstance(DataTable dataTable) {
            var type = typeof(Child1);
            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            return (Child1)m_factories[type].DynamicInvoke(dataTable);
        }
        public static BaseClass CreateInstance(DataSet dataSet) {
            var type = typeof(Child2);
            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            return (Child2)m_factories[type].DynamicInvoke(dataSet);
        }
        protected static void AddFactory<TArgs, T>(Func<TArgs, T> factory) {
            m_factories.Add(typeof(T), factory);
        }
    }
    public class Child1:BaseClass {
        Child1(DataTable dataTable) {
        }
        static Child1() {
            BaseClass.AddFactory((DataTable dt) => new Child1(dt));
        }
    }
    public class Child2:BaseClass {
        Child2(DataSet dataSet) {
        }
        static Child2() {
            BaseClass.AddFactory((DataSet ds) => new Child2(ds));
        }
    }
    public static class TestClass {
        public static void TestMethod() {
            var child2 = BaseClass.CreateInstance(new DataSet { });
            var child1 = BaseClass.CreateInstance(new DataTable { });
        }
    }
