    MultiselectList list = /* The list from your xaml */;
    foreach (ColorModel model in allModels) {
        ColorViewModel viewModel = new ColorViewModel(model);
        if (shouldBeSelected(model)) {
            list.SelectedItems.Add(viewModel);
        }
        AllColors.Add(viewModel);
    }
