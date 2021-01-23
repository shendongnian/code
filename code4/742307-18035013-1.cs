      ImageViewModel _viewModel;
      public ImageViewModel imageViewModel
      {
          get{ return _viewModel; }
          set
          {
              _viewModel=value;
              OnPropertyChanged("imageViewModel");
          }
    }
