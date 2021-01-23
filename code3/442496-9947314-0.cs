    public class MenuRepository : IMenuRepository
    {
        public bool Save(Menu menu)
        {
            if (!menu.VerifyLevels())
                return false;
    
            if (menu.ID == 0)
                context.Menus.AddObject(menu);
            else
                context.ObjectStateManager.ChangeObjectState(menu, EntityState.Modified);
            context.SaveChanges();
    
            returns true;
        }
    }
