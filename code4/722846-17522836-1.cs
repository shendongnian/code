    using System.Windows;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Microsoft.Phone.Controls;
    public partial class View : PhoneApplicationPage
    {
        public View()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
        }
    }
    public class MyViewModel
    {
        private ICommand setLike;
        public ICommand SetLikeCommand
        {
            get
            {
                return this.setLike ?? (this.setLike = new RelayCommand(this.SetLike));
            }
        }
        public Visibility LikeVisibility
        {
            get
            {
                return Visibility.Visible;
            }
        }
        private void SetLike()
        {
            var t = "fsdf";
        }
    }
