    <ComboBox>
      <ComboBox.Resources>
        <Style TargetType="TextBlock">
          <Style.Triggers>
            <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ComboBoxItem}}" Value="True">
              <Setter Property="Foreground" Value="White" />
            </Trigger>
          </Style.Triggers>
        </Style>
      </ComboBox.Resources>
      <ComboBox.ItemContainerStyle>
        <Style TargetType="ComboBoxItem" x:Key="ContainerStyle">
          <Style.Triggers>
            <Trigger Property="IsSelected" Value="True">
              <Setter Property="Background" Value="Red" />
            </Trigger>
          </Style.Triggers>
        </Style>
      </ComboBox.ItemContainerStyle>    
    </ComboBox>
