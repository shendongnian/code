     public MyClassViewModel ViewModel {get;set} 
     ctor()
     {
       this.ViewModel=new MyClassViewModel();
       this.DataContext=this.ViewModel;
     }
     private void textAddressLine1_Changed(object sender, RoutedEventArgs e)
     {  
       this.ViewModel.AddressLine1=textAddressLine1.Text;
     }
