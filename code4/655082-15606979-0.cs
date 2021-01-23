        [Export(typeof(IShell))]
        public class MainViewModel : Screen
        {
            public string Path{ get; set; }
        
            [Import]
            IWindowManager WindowManager {get; set;}
        
            public void Open()
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Text|*.txt|All|*.*";
                fd.FilterIndex = 1;
        
                fd.ShowDialog();
        
                Path= fd.FileName;
                NotifyOfPropertyChange("Path");
                
                WindowManager.ShowWindow(new BViewModel(), null, null);
            }    
        }
