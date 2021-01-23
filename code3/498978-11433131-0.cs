    public class MainPageViewmodel
    {
        public ICommand SaveCommand { get; set; }
        public MyDataViewmodel MyData { get; set; }
        public MyMetaDataViewmodel MyMetaData { get; set; }
        public MainPageViewmodel()
        {
            this.MyData = new MyDataViewmodel();
            this.MyMetaData = new MyMetaDataViewmodel();
        }
    }
    public class MyDataViewmodel
    {}
    public class MyMetaDataViewmodel
    {}
    
