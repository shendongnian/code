    <Button x:Name="Play" Content="" ClickMode="Press" BorderThickness="0" UseLayoutRounding="True" Height="120" Width="224">
        <Button.Style>
            <Style TargetType="{x:Type Button}">
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="..\Resources\Play 1.gif"/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Background">
                            <Setter.Value>
                                <ImageBrush ImageSource="..\Resources\Play 2.gif"/>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
             </Style>
        </Button.Style>
    </Button>
