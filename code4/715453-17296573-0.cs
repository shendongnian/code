    public ICommand btnAddGuest    // Command for opening child window
        {
            get
            {
                if (_btnAddGuest == null)
                {
                    _btnAddGuest = new DelegateCommand(delegate()
                    {
                        try
                        {
                            Guests guest = new Guests();
                            guest.ShowDialog();
    
                            // Add some Logic here and an is save check property to your GuestVM
                            // sample solution
                            // var vm = guest.DataContext as GuestViewModel;
                            // if(vm != null)
                            //     if(vm.IsSaved)
                            //     {
                            //         var model = vm.Guest as tblGuest;
                            //         Guests.Add(model);                // will add him to your list
                            //         Guest = model                     // will add him at your selected Guest
                            //     }
                        }
                        catch
                        {
                            Trace.WriteLine("working...", "MyApp");
                        }
                    });
                }
                return _btnAddGuest;
            }
        }
