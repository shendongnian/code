    using System.Windows;
    namespace WpfApplication1
    {
        public class ViewModel
        {
            public Point FinalDestination { get; private set; }
            public ViewModel()
            {
                FinalDestination = new Point(8, 8);
            }
        }
    }
