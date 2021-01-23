    <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Setter Property="IsEnabled" Value="false" />
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding ElementName=TextBox1, Path=(Validation.HasError)}" Value="false" />
                                <Condition Binding="{Binding ElementName=TextBox2, Path=(Validation.HasError)}" Value="false" />
                            <Setter Property="IsEnabled" Value="true" />
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
