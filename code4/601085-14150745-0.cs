    <UserControl.Resources>
        <SolidColorBrush x:Key="MenuActiveBackgroundColor" Color="Green"/>
        <SolidColorBrush x:Key="MenuInactiveBackgroundColor" Color="Tomato"/>
    </UserControl.Resources>
    
    <Grid>
        <Grid.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding AnyMenuIsActive}" Value="true">
                        <Setter Property="Grid.Background" Value="{DynamicResource MenuActiveBackgroundColor}"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding AnyMenuIsActive}" Value="false">
                        <Setter Property="Grid.Background" Value="{DynamicResource MenuInactiveBackgroundColor}"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
    </Grid>
