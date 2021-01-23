    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/FirstFloor.ModernUI;component/Assets/ModernUI.xaml" />
                <ResourceDictionary Source="/FirstFloor.ModernUI;component/Assets/ModernUI.Dark.xaml"/>
                <ResourceDictionary>
                    <framework:ModernContentLoader x:Key="ModernContentLoader"></framework:ModernContentLoader>
                    <wpfApplication4:Bootstrapper x:Key="Bootstrapper"></wpfApplication4:Bootstrapper>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
