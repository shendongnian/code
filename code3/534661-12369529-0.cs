    <ResourceDictionary>
        <ResourceDictionary.Merged>
                 <Source="GlassButton.xaml"/>
        </ResourceDictionary.Merged>
                <my:DepartmentDataSet x:Key="DepartmentDataSet" />
                <CollectionViewSource x:Key="DepViewSource" Source="{Binding Path=DEP, Source={StaticResource DepartmentDataSet}}" />
            </ResourceDictionary>
