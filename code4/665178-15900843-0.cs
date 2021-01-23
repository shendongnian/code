     <StackPanel>
        <GroupBox>
            <GroupBox.Header>
                <Label Content="GroupBox"/>
            </GroupBox.Header>
            <StackPanel>
                <Label x:Name="lbl_a" Content="A" Visibility="{Binding IsChecked, ElementName=chk_a, Converter={StaticResource boolToVis}}"  />
                <Label x:Name="lbl_b" Content="B" Visibility="{Binding IsChecked, ElementName=chk_b, Converter={StaticResource boolToVis}}"  />
            </StackPanel>
            <GroupBox.Style>
                <Style TargetType="GroupBox">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Visibility, ElementName=lbl_a}" Value="Collapsed" />
                                <Condition Binding="{Binding Visibility, ElementName=lbl_b}" Value="Collapsed" />
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
                                <Setter Property="GroupBox.Visibility" Value="Collapsed" />
                            </MultiDataTrigger.Setters>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </GroupBox.Style>
        </GroupBox>
    
        <CheckBox x:Name="chk_a" Content="A Visible" Grid.Column="0" Grid.Row="1" />
        <CheckBox x:Name="chk_b" Content="B Visible" Grid.Column="1" Grid.Row="1"  />
    
    </StackPanel>
