    <UserControl x:Class="TabControlItemTemplateDemo.View.MyTabControl"
             xmlns:ViewModel="clr-namespace:TabControlItemTemplateDemo" 
             xmlns:View1="clr-namespace:TabControlItemTemplateDemo.View" mc:Ignorable="d" >
    <UserControl.Resources>
        <DataTemplate x:Key="MyTabHeaderTemplate">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="0" Text="{Binding Header}" Width="80" Height="25" FontWeight="Bold"/>
            </Grid>
        </DataTemplate>
        <DataTemplate x:Key="CountryContentTemplate">
            <View1:CountryView DataContext="{Binding CurrentMyTabContentViewModel}"/>
        </DataTemplate>
        <DataTemplate x:Key="ContinentsContentTemplate">
            <View1:ContinentsView DataContext="{Binding CurrentMyTabContentViewModel}"/>
        </DataTemplate>
        <ViewModel:MyViewSelector x:Key="selector" 
                                           CountryTemplate="{StaticResource CountryContentTemplate}"
                                           ContintentsTemplate="{StaticResource ContinentsContentTemplate}" />
    </UserControl.Resources>
    <DockPanel>
        <TabControl ItemsSource="{Binding Tabs}" TabStripPlacement="Left" 
                    BorderThickness="0" Background="White"  
                    ItemTemplate="{StaticResource MyTabHeaderTemplate}"
                    ContentTemplateSelector="{StaticResource selector}">
        </TabControl>
    </DockPanel>
