        <ControlTemplate TargetType="{x:Type local:InfoBar}">
            <Grid Name="grid" Margin="4,0,4,0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="auto" />
                </Grid.ColumnDefinitions>
                ...
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property="IsError" Value="True" >
                    <Setter TargetName="grid" Property="Background" Value="LightPink" />
                </Trigger>
                <Trigger Property="IsError" Value="False" >
                    <Setter TargetName="grid" Property="Background" Value="LightYellow" />
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
    *In this solution you have to change the order: `ControlTemplate.Triggers` after `Grid` declaration.*
