    public void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            if (args.Files.Count > 0)
            {
                var userChosenbPhoto = args.Files[0].Name;
            }
            else
            {
                //user canceled picker
            }
        }
