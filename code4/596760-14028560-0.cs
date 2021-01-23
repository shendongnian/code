    <ListView Name="YourList">
            <ListViewItem Content="1234" />
            <ListViewItem Content="1234" />
            <ListViewItem Content="1234" />
        </ListView>
        <Button Content="OK">
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedItem, ElementName=YourList}"
                                     Value="{x:Null}">
                            <Setter Property="IsEnabled"
                                    Value="False" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
