    <Window.Resources>
        <ContextMenu x:Key="FooMenu">
            <MenuItem Header="Help" Command="{Binding HelpCommand}"/>
        </ContextMenu>
        <DataTemplate x:Key="ItemTemplate">
            <!-- context menu on header -->
            <TextBlock Text="{Binding Header}" ContextMenu="{StaticResource FooMenu}"/>
        </DataTemplate>
        <DataTemplate x:Key="ContentTemplate">
            <Grid Background="#FFE5E5E5">
                <!-- context menu on data grid -->
                <DataGrid ContextMenu="{StaticResource FooMenu}"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <Window.DataContext>
        <WpfApplication2:TestViewModel/>
    </Window.DataContext>
    <Grid>
        <TabControl 
            ItemsSource="{Binding Items}" 
            ItemTemplate="{StaticResource ItemTemplate}" 
            ContentTemplate="{StaticResource ContentTemplate}" />
    </Grid>
