    <ListBox Name="listBox" MouseMove="listBox_MouseMove" SelectionChanged="listBox_SelectionChanged">
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type local:CustomListBoxItem}">
                    <Style.Triggers>
                        <Trigger Property="IsVirtuallySelected" Value="true">
                            <Setter Property="Background" Value="SkyBlue"/>
                        </Trigger>
                        <Trigger Property="IsVirtuallySelected" Value="false">
                            <Setter Property="Background" Value="White"/>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </ListBox.ItemContainerStyle>
    </ListBox>
