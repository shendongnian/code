    public abstract class MenuItem
    {
        protected string m_Title;
    }
    
    public class ContainerItem : MenuItem
    {
        void Foo()
        {
            var derivedItem = new ContainerItem();
            derivedItem.m_Title = "test"; // works fine
    
            var baseItem = (MenuItem)derived;
            baseItem.m_Title = "test"; // compiler error!
        }
    }
