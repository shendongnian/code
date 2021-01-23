    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
                 <ResourceDictionary Source="GlassButton.xaml"/>
        </ResourceDictionary.MergedDictionaries>
                <my:DepartmentDataSet x:Key="DepartmentDataSet" />
                <CollectionViewSource x:Key="DepViewSource" Source="{Binding Path=DEP, Source={StaticResource DepartmentDataSet}}" />
            </ResourceDictionary>
