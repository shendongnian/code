    public class ComponentA : Component { }
    public class ComponentB : Component { }
    public class Component { }
    public class ComponentList<T> : List<T> where T : Component
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComponentList<Component> MasterList = new ComponentList<Component>();
            MasterList.Add(new ComponentA());
            MasterList.Add(new ComponentB());
            for (int i = 0; i < MasterList.Count; i++)
            {
                if (MasterList[i] is ComponentA)
                {
                }
            }
        }
    }
