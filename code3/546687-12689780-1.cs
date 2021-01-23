    [Flags]
    public enum RKP
    {
        LowContrast = 0,
        MediumContrast = 1,         // bit 0
        HighContrast = 2,           // bit 1
        LowSpeechVolume = 0,
        MediumSpeechVolume = 4,     // bit 2
        HighSpeechVolume = 8,       // bit 3
        LowBuzzerVolume = 0,
        MediumBuzzerVolume = 16,    // bit 4
        HighBuzzerVolume = 32,      // bit 5
        ExitIndication = 0,
        EntryIndication = 64,       // bit 6
    }
    contrastComboBox.ItemsSource = new[] { RKP.LowContrast, RKP.MediumContrast, RKP.HighContrast };
    contrastComboBox.SelectedItem = currentValue & (RKP.MediumContrast | RKP.HighContrast);
    //and so on for each combo box...
    //and when you want the result:
    RKP combinedFlag = (RKP)contrastComboBox.SelectedItem | //other combo box items
