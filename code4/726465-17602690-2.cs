    <RadioButton IsChecked="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=ListBoxItem, AncestorLevel=1}, Path=IsSelected}" VerticalAlignment="Center" Margin="3,0,3,3">
    <RadioButton.Style>
        <Style TargetType="RadioButton">
            <Style.Triggers>
                <DataTrigger Value="True">
                    <DataTrigger.Binding>
                        <MultiBinding Converter="{StaticResource guidMatchConverter}">
                            <Binding Path="ID" />
                            <Binding RelativeSource="{RelativeSource FindAncestor, AncestorType=ListBox, AncestorLevel=1}" Path="DataContext.PreviousBestSkillLevelID" />
                        </MultiBinding>
                    </DataTrigger.Binding>
                    <DataTrigger.Setters>
                        <Setter Property="Effect">
                            <Setter.Value>
                                <DropShadowEffect BlurRadius="4" Color="Yellow" Direction="0" ShadowDepth="0" />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger.Setters>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </RadioButton.Style>
