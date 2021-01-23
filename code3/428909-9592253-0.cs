    <Window.Resources>
        <my:ColorConverter x:Key="colorConverter" />
        <Style TargetType="RichTextBox">
        <Style.Triggers>            
            <Trigger Property="IsMouseOver" Value="True">                    
                  <Setter Property="Background">
                    <Setter.Value>
                            <Binding Converter="{StaticResource colorConverter}"/>
                    </Setter.Value>
                </Setter>
            </Trigger>
        </Style.Triggers>
    </Style> 
    </Window.Resources> 
