     <Fluent:RibbonWindow.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Skins/MainSkin.xaml" />
            </ResourceDictionary.MergedDictionaries>
            <DataTemplate DataType="{x:Type local:ViewModelWithSomeCoolthingsClass}">
              <local:MyViewForViewModelWithSomeCoolthingsClass />
            </DataTemplate>
        </ResourceDictionary>      
     </Fluent:RibbonWindow.Resources>
