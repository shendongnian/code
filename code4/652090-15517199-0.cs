        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static async Task<IStorageFile> FileFromPicker(string identity)
        {
            FileOpenPicker picker = new FileOpenPicker();
            setFileTypes(picker);
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SettingsIdentifier = identity;
            var storageFile = await picker.PickSingleFileAsync();
                        
            return storageFile;
        }
