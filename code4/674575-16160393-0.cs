         <ComboBox Canvas.Left="10" Canvas.Top="10" DisplayMemberPath="Name" ItemsSource="{Binding Path=Items}" SelectedItem="{Binding Mode=TwoWay, Path=SelectedItem}" SelectedValuePath="Process" Width="200">
            <ComboBox.Style>
                <Style TargetType="ComboBox">
                    <Setter Property="IsEnabled" Value="True"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=Items.Count}" Value="0">
                            <Setter Property="IsEnabled" Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ComboBox.Style>
        </ComboBox>
        <TextBlock Canvas.Left="10" Canvas.Top="10" Text="No instances have been found!" >
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Setter Property="Visibility" Value="Collapsed"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=Items.Count}" Value="0">
                            <Setter Property="Visibility" Value="Visible"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBlock.Style>
        </TextBlock>
