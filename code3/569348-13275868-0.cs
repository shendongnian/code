    <Application.Resources>
        <Style TargetType="TextBlock" x:Key="HoverUnderlineStyle">
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="TextBlock.TextDecoration" Value="Underline" />
                </Trigger>
            </Style.Triggers>
        </Style>
    </Application.Resources>
    <TextBlock Style="{StaticResource HoverUnderlineStyle}" />
