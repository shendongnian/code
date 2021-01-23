    using System.Collections.Generic;
    using System.Linq;
      
    class TestAttribute : System.Attribute { }
    class State
    {
        [Test] string name;
        [Test] string address;
        [Test] public string name2;
        [Test] public string address2;
        float height;
        public State(string name_, string address_, float height_)
        {
            name = name_;
            address = address_;
            height = height_;
            name2 = name_ + "2";
            address2 = address_ + "2";
        }
    }
    public class Program
    {
        static void ShowFields<T>(IEnumerable<T> fieldList)
        {
            foreach (var field in fieldList)
            {
                System.Console.WriteLine(field.ToString());
            }
        }
        public static void Main(string[] args)
        {            
            State s = new State("Bob", "221 B Baker Street", 5.4f);
            System.Type stateType = typeof(State);
            System.Reflection.FieldInfo[] publicFieldList = stateType.GetFields();
            System.Console.WriteLine("----all public fields----");
            ShowFields(publicFieldList);
            System.Console.WriteLine("----all non public or instance fields----");
            System.Reflection.FieldInfo[] nonPublicFieldList;
            nonPublicFieldList = stateType.GetFields(System.Reflection.BindingFlags.NonPublic| System.Reflection.BindingFlags.Instance);
            ShowFields(nonPublicFieldList);
            var customAttributeFieldList = from t in stateType.GetFields()
            where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
            select t;
            System.Console.WriteLine("----only public fields marked with a particular custom attribute----");
            ShowFields(customAttributeFieldList);
        }
    }
