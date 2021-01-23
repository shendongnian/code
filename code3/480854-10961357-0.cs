    <Style TargetType="DataGridCell" x:Key="ActiveCellStyle">
        <Setter Property="Foreground" Value="Black"/>
            <Style.Triggers>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding Type}" Value="0"/>
                        <Condition Binding="{Binding RelativeSource={RelativeSource Self},
                                                     Path=IsSelected}"
                                           Value="False"/>
                    </MultiDataTrigger.Conditions>
                    <Setter Property="Background" Value="#FFDFE6ED"/>
                </MultiDataTrigger>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding Type}" Value="0"/>
                    <Condition Binding="{Binding RelativeSource={RelativeSource Self},
                                                 Path=IsSelected}"
                               Value="True"/>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="#FF6CAFF1"/>
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
