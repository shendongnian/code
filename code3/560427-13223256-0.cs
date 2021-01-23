    private static void OnTestChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MyControl c = d as MyControl;
                ViewModelType vm = c.DataContext as ViewModelType;
                vm.Property = e.New;
                Console.WriteLine(e.NewValue);
            }
