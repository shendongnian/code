    public class LocalizerDecorator : IMenuRepository menuRepository
    {
         private IMenuRepository originalRepository;
         private ILocalizeMenus menuLocalization;
         public LocalizerDecorator(IMenuRepository originalRepository, ILocalizeMenus menuLocalization)
         {
            this.originalRepository = originalRepository;
            this.menuLocalization = menuLocalization;
         }
    
         public Menu GetMenu(string MENU_TYPE)
         {
            var result = this.originalRepository.GetMenu(TYPE);
            this.menuLocalization.LocalizeAllText(result);
            return result;
         }
    
    }
