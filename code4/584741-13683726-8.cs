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
            var baseItem = (MenuItem)something;
            baseItem.m_Title = "Should I be allowed to change this?"; // #1
        }
    }
