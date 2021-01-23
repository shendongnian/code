    public class AppBootstrapper : BootstrapperBase
    {
    
         public AppBootstrapper()
         {
             Start(); // THIS IS WHAT CAUSES THE FRAMEWORK TO INITIALIZE
         }
    
         protected override void Configure()
         {  
             // DIFFERENT CONFIGURATION GOES HERE
         }
    
         protected override object GetInstance(Type service, string key)
         {
             // DI CONTAINER RELATED CONFIGURATION
         }
    
         protected override IEnumerable<object> GetAllInstances(Type service)
         {
             // DI CONTAINER RELATED CONFIGURATION
         }
    
         protected override void BuildUp(object instance)
         {
             // DI CONTAINER RELATED CONFIGURATION
         }
    
         protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
         {
             // ANY CUSTOM BEFORE-START CUSTOMIZATION OR PROCESSING CAN TAKE PLACE HERE
             DisplayRootViewFor<SPECIFIY_ROOT_VIEW_MODEL_HERE>(); // THIS IS WHAT DISPLAYS THE MAIN WINDOW, IF YOU DON'T CALL THIS NO UI WILL BE SHOWN
         }
    }
