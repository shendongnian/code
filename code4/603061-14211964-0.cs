    public class MyToolWindow: ToolWindowPane {
        void SomeMethod() {
            var myControl = new MyControl(this);
        }
    }
    
    public class MyControl: UserControl {
        public MyControl(IServiceProvider serviceProvider) {
            // Now you can call serviceProvider.GetService
        }
    }
