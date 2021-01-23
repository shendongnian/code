    <Border.Style>
      <Style TargetType="{x:Type Border}">
        <Setter Property="BorderBrush"
                Value="Transparent" />
        <Style.Triggers>
          <Trigger Property="IsMouseOver"
                    Value="True">
            <Trigger.EnterActions>
              <BeginStoryboard>
                <Storyboard>
                  <ColorAnimation Duration="0:0:0.01"
                                  Storyboard.TargetProperty="BorderBrush.Color"
                                  To="LightGray" />
                </Storyboard>
              </BeginStoryboard>
            </Trigger.EnterActions>
            <Trigger.ExitActions>
              <BeginStoryboard>
                <Storyboard>
                  <ColorAnimation Duration="0:0:0.6"
                                  Storyboard.TargetProperty="BorderBrush.Color"
                                  To="Transparent" />
                </Storyboard>
              </BeginStoryboard>
            </Trigger.ExitActions>
          </Trigger>
        </Style.Triggers>
      </Style>
    </Border.Style>
