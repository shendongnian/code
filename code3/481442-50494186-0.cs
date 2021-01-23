    <User Control ...namespaces...>
        <UserControl.Resources>
            <ResourceDictionary x:Key="FooDictionary">
                ...converters...
    
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="MyButton.xaml"/>
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </UserControl.Resources>
         ...the rest of the control...
    </UserControl>
