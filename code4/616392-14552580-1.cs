    <ControlTemplate TargetType="Button">
        <Border Name="border" BorderThickness="0" Background="{TemplateBinding Background}">
            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" Width="15" Height="15" />
        </Border>
        <ControlTemplate.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{TemplateBinding IsMouseOver}" Value="false"/>
                    <Condition Binding="{Binding InitialCondition}" Value="false"/>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="GreyCross.png" />
                    </Setter.Value>
                </Setter>
            </MultiDataTrigger>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{TemplateBinding IsMouseOver}" Value="true"/>
                    <Condition Binding="{Binding InitialCondition}" Value="false"/>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="RedCross.png" />
                    </Setter.Value>
                </Setter>
            </MultiDataTrigger>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{TemplateBinding IsMouseOver}" Value="false"/>
                    <Condition Binding="{Binding InitialCondition}" Value="true"/>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="GreyTick.png" />
                    </Setter.Value>
                </Setter>
            </MultiDataTrigger>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{TemplateBinding IsMouseOver}" Value="true"/>
                    <Condition Binding="{Binding InitialCondition}" Value="true"/>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="GreenTick.png" />
                    </Setter.Value>
                </Setter>
            </MultiDataTrigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
