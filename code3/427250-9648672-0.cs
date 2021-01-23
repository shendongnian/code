    <Page.DataContext>
        <Samples:TabBindingViewModels />
    </Page.DataContext>
    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="ContentTemplate" 
                          DataType="{x:Type Samples:TabBindingViewModel}">
                <TextBlock Text="{Binding Content}"/>
            </DataTemplate>
        </Grid.Resources>
        <TabControl ContentTemplate="{StaticResource ContentTemplate}"  
                    DisplayMemberPath="Header" ItemsSource="{Binding Items}" />
    </Grid>
