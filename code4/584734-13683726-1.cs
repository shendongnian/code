    public abstract class MenuItem
    {
        protected string m_Title;
    }
    public class SomeTypeOfItem : MenuItem
    {
        protected new string m_Title;
    }
    
    public class ContainerItem : MenuItem
    {
        void Foo()
        {
            var baseItem = (MenuItem)something; // #1
        }
    }
