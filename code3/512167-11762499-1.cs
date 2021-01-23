    <Button.Style>
        <Style TargetType="{x:Type Button}">
            <Setter Property="IsEnabled" Value="True" />
            <Style.Triggers>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding Text, ElementName=textBox1}" Value="{x:Static s:String.Empty}" />
                        <Condition Binding="{Binding Text, ElementName=textBox2}" Value="{x:Static s:String.Empty}" />
                        <Condition Binding="{Binding Text, ElementName=TextBoxAge}" Value="{x:Static s:String.Empty}" />
                    </MultiDataTrigger.Conditions>
                    <Setter Property="IsEnabled" Value="False" />
                </MultiDataTrigger>
            </Style.Triggers>
        </Style>
    </Button.Style>
