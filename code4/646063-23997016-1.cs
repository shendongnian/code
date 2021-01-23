    FileOpenPicker singleFilePicker = new FileOpenPicker();
            singleFilePicker.ViewMode = PickerViewMode.Thumbnail;
            singleFilePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            singleFilePicker.FileTypeFilter.Add(".jpg");
            singleFilePicker.FileTypeFilter.Add(".jpeg");
            singleFilePicker.FileTypeFilter.Add(".png");
            singleFilePicker.PickSingleFileAndContinue();
