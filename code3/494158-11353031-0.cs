    <MenuItem>
        <MenuItem.Style>
            <Style TargetType="{x:Type MenuItem}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding HasSelection}" Value="false">
                        <Setter Property="IsEnabled" Value="false"/>
                        <Setter Property="Header">
                            <Setter.Value>
                                <AccessText Text="Save Selected File _As..."/>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding HasSelection}" Value="true">
                        <Setter Property="IsEnabled" Value="true"/>
                        <Setter Property="Header">
                            <Setter.Value>
                                <AccessText Text="{Binding SelectedFile.Filename, StringFormat=Save {0} _As...}"/>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </MenuItem.Style>
    </MenuItem>
