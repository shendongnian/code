        public EnumCameraVariantToLocalizedStringConverter()
        {
        }
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)(CameraVariant)value;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = (int)value;
            switch (index)
            {
                case 0:
                    return CameraVariant.Undefined;
                case 1:
                    return CameraVariant.FirstPerson;
                case 2:
                    return CameraVariant.ThirdPerson;
                case 3:
                    return CameraVariant.Flight;
            }
            return index;
        }
    }
