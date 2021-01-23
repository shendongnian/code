    public class ModuleA
    {
       public ModuleA(IRegionManager regionManager) 
       {
          _shellRegionManager = regionManager;
       }
       public bool Initialize()
       {
          IRegion tabRegion = _shellRegionManager.Regions["tabRegion"];
          //You may actually want to use your container to resolve the common view, but 
          //I'm creating it here for demonstration sake.
          Object commonView = new CommonView();
 
          //This is the important part... setting the 3rd parameter to true gives us 
          //a new locally scoped region manager, so Prism won't complain about the fact
          //that the common view contains regions with names that have already been 
          //registered in other modules
          IRegionManager localRM = tabRegion.Add(new CommonView, "ModuleACommon", true);
          
          IRegion commonContentRegion = localRM.Regions["ContentRegion"];
          commonContentRegion.Add(new ModuleAView()); 
   
       }
       IRegionManager _shellRegionManager;
    }
