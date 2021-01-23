    <Button Background="Aquamarine">
    <Button.Style>
      <Style TargetType="Button">
        <Style.Triggers>
          <Trigger Property="IsPressed" Value="True">
            <Trigger.EnterActions>
              <BeginStoryboard>
                <Storyboard>
                  <DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="0:0:1.5" From="1" To="0"/>
                </Storyboard>
              </BeginStoryboard>
            </Trigger.EnterActions>
          </Trigger>
        </Style.Triggers>
      </Style>
    </Button.Style>    
