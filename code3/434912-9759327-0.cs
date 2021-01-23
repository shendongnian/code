    <Control>
            <Control.Style>
                <Style TargetType="Control">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="Control">
                                <StackPanel x:Name="stackPanel">
                                    <TextBlock Margin="0,0,0,0" Text="Notes:" />
                                    <TextBlock x:Name="txtNotes" Margin="50,0,0,0" Text="{Binding Path=notes}" />
                                </StackPanel>
                                <ControlTemplate.Triggers>
                                    <Trigger SourceName="txtNotes" Property="TextBlock.Text" Value="">
                                        <Setter TargetName="stackPanel" Property="Control.Visibility" Value="Collapsed"/>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Control.Style>
        </Control>
