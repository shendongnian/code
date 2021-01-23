    <CheckBox>
      <CheckBox.Style>
         <Style TargetType={x:Type CheckBox}>
            <Style.Triggers>
              <MultiDataTrigger>
                 <MultiDataTrigger.Conditions>
                      <Condition Binding="{Binding Path="SearchEngineCompassLogView.FilterSearch.IsFilterAllEnable" Source="{StaticResource CompassLogView}" Value="True"/>
                      <Condition Binding="{Binding Path="SearchEngineCompassLogView.FilterSearch.IsFilterVisible" Source="{StaticResource CoreServiceLogView}" Value="True"/>
                  </MultiDataTrigger.Conditions>
                  <Setter Property="CheckBox.IsChecked" Value="True"/>
              </MultiDataTrigger>
            </Style.Triggers>
         </Style>
      </CheckBox.Style>
    </CheckBox>
