     <Style x:Key="TextBoxValidationStyle" TargetType="{x:Type TextBox}">
        <Setter Property="Validation.ErrorTemplate">
          <Setter.Value>
            <ControlTemplate>
              <DockPanel IsEnabled="{Binding ElementName=customAdorner, Path=AdornedElement.IsEnabled}">
                <AdornedElementPlaceholder x:Name="customAdorner">
                  <Border x:Name="Border" BorderThickness="1">
                    <Border.Style>
                      <Style TargetType="Border">
                        <Style.Triggers>
                          <Trigger Property="IsEnabled" Value="False">
                            <Setter Property="BorderBrush" Value="Transparent" />
                          </Trigger>
                          <Trigger Property="IsEnabled" Value="True">
                            <Setter Property="BorderBrush" Value="Red" />
                          </Trigger>
                        </Style.Triggers>
                      </Style>
                    </Border.Style>
                  </Border>
                </AdornedElementPlaceholder>
              </DockPanel>
            </ControlTemplate>
          </Setter.Value>
        </Setter>
      </Style>
