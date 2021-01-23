        // in your PCL project
        public interface IVirtualScreen {
             Rectangle Current { get; 
        }
    
        // in your desktop project
        public interface DesktopScreen : IVirtualScreen {
           public Rectangle Current { 
             get {
                return System.Windows.Forms.SystemInformation.VirtualScreen;
           }
        }
