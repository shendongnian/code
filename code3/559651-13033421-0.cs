    <ContentControl x:Name="MyContentControl">
        <ContentControl.Style>
            <Style TargetType="{x:Type ContentControl}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding }" Value="Home">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <local:MyHomeUsercontrol />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding }" Value="Players">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <local:MyPlayersUsercontrol />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding }" Value="Team">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <local:MyTeamUsercontrol />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
            </Style>
        </ContentControl.Style>
    </ContentControl>
