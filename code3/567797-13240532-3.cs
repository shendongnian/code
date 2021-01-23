    <UserControl>
        <UserControl.Resources>
            <ControlTemplate x:Key="usingColumns">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                        
                    <ListBox Grid.Column="0" ItemsSource="{Binding DataOneItems}" />
                    <ListBox Grid.Column="1" ItemsSource="{Binding DataTwoItems}" />
                </Grid>
       
            </ControlTemplate>
            <ControlTemplate x:Key="usingRows">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>
        
                    <ListBox Grid.Row="0" ItemsSource="{Binding DataOneItems}" />
                    <ListBox Grid.Row="1" ItemsSource="{Binding DataTwoItems}" />
                </Grid>
            </ControlTemplate>
        </UserControl.Resources>
        <UserControl.Style>
            <Style>
                <Setter Property="UserControl.Template" Value="{StaticResource usingColumns}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ShowVertically}" Value="true">
                        <Setter Property="UserControl.Template" Value="{StaticResource usingRows}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </UserControl.Style>
    </UserControl>
