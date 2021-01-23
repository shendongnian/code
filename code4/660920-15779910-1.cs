    <StackPanel.Resources>
            <Style x:Key="alternatingListViewItemStyle" TargetType="{x:Type ListViewItem}">
                <Style.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                        <Setter Property="Background" Value="#FFD9F2BF"></Setter>
                    </Trigger>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                        <Setter Property="Background" Value="White"></Setter>
                    </Trigger>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsSelected" Value="True"></Condition>
                            <Condition Property="ItemsControl.AlternationIndex" Value="0"></Condition>
                        </MultiTrigger.Conditions>
                        <Setter Property="Background" Value="LightGreen"></Setter>
                    </MultiTrigger>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsSelected" Value="True"></Condition>
                            <Condition Property="ItemsControl.AlternationIndex" Value="1"></Condition>
                        </MultiTrigger.Conditions>
                        <Setter Property="Background" Value="LightBlue"></Setter>
                    </MultiTrigger>
                </Style.Triggers>
            </Style>
        </StackPanel.Resources>
