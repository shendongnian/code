    <Rectangle>
      <Rectangle.Style>
        <Style TargetType="Rectangle">
          <Style.Triggers>
            <DataTrigger Binding="{Binding AlarmLevel, Converter={StaticResource AlarmLevelConverter}}" Value="True">
              <Setter Property="Fill">
                <Setter.Value>
                  <SolidColorBrush Color="Red" />
                </Setter.Value>
              </Setter>
            </DataTrigger>
            <DataTrigger Binding="{Binding AlarmLevel, Converter={StaticResource AlarmLevelConverter}}" Value="False">
              <Setter Property="Fill">
                <Setter.Value>
                  <SolidColorBrush Color="Black" />
                </Setter.Value>
              </Setter>
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </Rectangle.Style>
    </Rectangle>
