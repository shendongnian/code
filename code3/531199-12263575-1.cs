    <UserControl ...>
        <UserControl.Resources>
            <DataTemplate DataType="{x:Type TextBoxAndCommandPresenter}">
                <StackPanel Orientation="Horizontal">
                    <Label Content="{Binding Description}"/>
                    <TextBox Text="{Binding Value}"/>
                    <Button Command="{Binding Command}">Click</Button>
                </StackPanel>
            </DataTemplate>
        </UserControl.Resources>
    
        <ContentPresenter Content="{Binding}"/>
    </UserControl>
