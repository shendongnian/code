         <Style  TargetType="{x:Type telerik:RadListBoxItem}">
                <Style.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                        <Setter Property="Background" Value="#19f39611"></Setter>
                    </Trigger>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                        <Setter Property="Background" Value="#19000000"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ResourceDictionary>
    </UserControl.Resources>
