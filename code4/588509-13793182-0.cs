    <Grid.Resources>
        <local:MyImageConverter x:Key="MyImageConverter"/>
    </Grid.Resources>
    <Image Grid.Column="0" Grid.Row="0">
        <Image.Style>
            <Style TargetType="{x:Type Image}">
                <Setter Property="Source" Value="Icons/ConditionFalse.png"/>
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding
                                Converter="{StaticResource MyImageConverter}">
                                <Binding ElementName="myTextBox" Path="Text"/>
                                <Binding ElementName="myLabel" Path="Content"/>
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="Source" Value="Icons/ConditionTrue.png"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
    </Image>
    
