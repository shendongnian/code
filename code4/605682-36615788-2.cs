    <Application.Resources>
       <ResourceDictionary >
            <ResourceDictionary.MergedDictionaries >  
                <ResourceDictionary Source="styles.xaml"/>
            </ResourceDictionary.MergedDictionaries>
            <!-- You can declare additional resources before or after Merged dictionaries, but not both -->
            <SolidColorBrush x:Key="DefaultBackgroundColorBrush" Color="Cornsilk" />
            <Style x:Key="DefaultBackgroundColor" TargetType="TextBox">
                <Setter Property="Background" Value="{StaticResource DefaultBackgroundColorBrush}" />
            </Style>
        </ResourceDictionary>
    </Application.Resources>
