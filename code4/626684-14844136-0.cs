       <Image.Style>
            <Style TargetType="{x:Type Image}">
                <Style.Triggers>
                    <Trigger Property="Visibility" Value="Visible">
                        <Trigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource FlashErrorImage}" />
                        </Trigger.EnterActions>
                        <Trigger.ExitActions>
                            <RemoveStoryboard BeginStoryboardName="FlashErrorImage" />
                        </Trigger.ExitActions>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
