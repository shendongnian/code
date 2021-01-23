    <Style TargetType="Control" x:Key="TextFieldEntry">
        <Setter Property="Background" Value="AliceBlue" />
        <Style.Triggers>
            <DataTrigger Binding="{Binding Path=IsDirty}" Value="True">
                <Setter Property="BorderBrush">
                    <Setter.Value>
                        <SolidColorBrush Color="#FFF9D74B" />
                    </Setter.Value>
                </Setter>
            </DataTrigger>
            <DataTrigger Binding="{Binding Path=IsDirty}" Value="False">
                <Setter Property="BorderBrush">
                    <Setter.Value>
                        <SolidColorBrush Color="#FF98F329" />
                    </Setter.Value>
                </Setter>
            </DataTrigger>
        </Style.Triggers>
    </Style>
