    public class MyXamlViewClass : UserControl{ // could be a window, or whatever you are using.
        public MyXamlViewClass(MyDataContextClass vm){
            DataContext = vm;
            InitializeComponent();//If I remember the method name correctly
        }
    }
