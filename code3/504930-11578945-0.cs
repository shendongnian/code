        <Window.Resources>
            <Style TargetType="{x:Type MenuItem}">
                <Style.Triggers>
                    <Trigger Property="IsEnabled" Value="False">
                        <Setter Property="Background" Value="Black"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        <Grid>
            <TextBox >
                <TextBox.ContextMenu>
                    <ContextMenu>
                        <Menu>
                            <MenuItem Header="Add" IsEnabled="False"/>
                            <MenuItem Header="Delete"/>
                        </Menu>
                    </ContextMenu>
                </TextBox.ContextMenu>
            </TextBox>
        </Grid>
