    [Component]
    public class CoolPluginMenuRegistrar : IMenuRegistrar
    {
        public void Register(ApplicationMenu menu)
        {
            menu.File.Add("mnuMyPluginMenuName", "Load jokes");
        }
    }
