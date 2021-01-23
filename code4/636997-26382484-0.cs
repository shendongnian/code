    public partial class mywindow : Window
        {
            public mywindow()
            {
                BusinessLogic.Initialize();
                InitializeComponent();
                var a = (MyPage)myframe.Content;
             }
    }
