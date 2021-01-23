        <ToggleButton Grid.Column="0" x:Name="PauseButton">
            <ToggleButton.Content>
                <Path Name="PauseIcon" Data="M0,0 0,27 8,27 8,0z M14,0 14,27 22,27 22,0">
                    <Path.Style>
                        <Style TargetType="{x:Type Path}">
                            <Setter Property="Fill" Value="White"></Setter>
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding ElementName=PauseButton, Path=IsChecked}" Value="True">
                                    <Setter Property="Fill" Value="Black"></Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </Path.Style>
                </Path>
            </ToggleButton.Content>
        </ToggleButton>
