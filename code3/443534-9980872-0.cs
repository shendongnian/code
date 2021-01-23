     public void Open()
            {
                var dialogViewModel = IoC.Get<DialogViewModel>();
                dialogViewModel.Dimension1 = "123";
                dialogViewModel.Dimension2 = "456";
                var result = WindowManager.ShowDialog(dialogViewModel);
            }
