    namespace TestScope
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ModelView myModelView = new ModelView();
                Cabbage myCabbage = new Cabbage();
                myCabbage.Leaves = 99;
                myModelView.updateCabbageLeaves(myCabbage);
            }
        }
        public class ModelView
        {
            public Cabbage Cabbage { get; set; }
            public void updateCabbageLeaves(Cabbage myCabbage)
            {
                Cabbage = myCabbage.Leaves;
            }
        }
        public class Cabbage
        {
             public int Leaves { get; set; }
        }
    }
