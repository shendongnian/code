    public class App
    {
        private void OnAppStart()
        {
            var model = new MainModel();
            var vm = new MainVM();
            var view = new MainWindow();
    
            vm.Model = model;
            view.DataSource = vm;
    
            view.Show();
        }
    }
 
