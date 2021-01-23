    public MediaPickerField MediaPicker
            {
                get
                {
                    return (MediaPickerField)ContentItem.As<HeaderPart>().Fields.First(x => x.Name == "Image");
                }
            }
