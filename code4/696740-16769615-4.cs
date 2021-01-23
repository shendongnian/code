    using System.Windows;
    using System.ComponentModel.DataAnnotations;
    
    namespace DataAnnotations
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new Cl();
            }
        }
    
        public class Cl
        {
            private decimal _cartPayment;
            [Required]
            [RegularExpression(@"^\d+(\.\d{1,2})?$")]
            public decimal CartPayment
            {
                get { 
                    return _cartPayment; }
                set
                {
                    _cartPayment = value;
                }
            }
        }
    }
