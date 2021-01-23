    manufacturer.PropertyChanged += ChooseManufacturer_PropertyChanged;
    pages.Add(manufacturer);
    ....
    void ChooseManufacturer_PropertyChanged(object src, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SelectedManufacturer")
        {
            switch ((WizardChooseManufacturerViewModel)src).SelectedManufacturer)
            {
                // You'll want to check any existing ManufactorerViewModels 
                // and remove them as well if needed
                case "A":
                    Pages.Add(new ManufacturerAViewModel);
                    break;
                case "B":
                    Pages.Add(new ManufacturerBViewModel);
                    break;
            }
        }
    }
