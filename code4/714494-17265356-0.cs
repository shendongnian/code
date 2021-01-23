    <ContentControl Content="{Binding SelectedViewModel">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type viewModels:LoginViewModel}">
                <userControls:LoginView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type viewModels:MainViewModel}">
               <userControls:MainView />
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
