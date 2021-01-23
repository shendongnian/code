    <StackPanel.Resources>
       <Style x:Key="alternatingListViewItemStyle"
              TargetType="{x:Type ListViewItem}">
          <Style.Triggers>
             <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                <Setter Property="Background" Value="#FFD9F2BF"/>
             </Trigger>
             <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                <Setter Property="Background" Value="White"/>
             </Trigger>
             <MultiTrigger>
                <MultiTrigger.Conditions>
                   <Condition Property="IsSelected" Value="True"/>
                   <Condition Property="ItemsControl.AlternationIndex" Value="0"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" Value="LightGreen"/>
             </MultiTrigger>
             <MultiTrigger>
                <MultiTrigger.Conditions>
                   <Condition Property="IsSelected" Value="True"/>
                   <Condition Property="ItemsControl.AlternationIndex"
                              Value="1"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" Value="LightBlue"/>
             </MultiTrigger>
          </Style.Triggers>
       </Style>
    </StackPanel.Resources>
