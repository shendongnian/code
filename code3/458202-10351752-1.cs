    <System:String x:Key="Test">Add new: </System:String>
    
    <Style TargetType="{x:Type local:CustomButton}">
        <Setter Property="ToolTip" 
                Value="{Binding RelativeSource={RelativeSource Self}, Path=Subject}"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:CustomButton}">
                    <Border Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="Auto"/>
                                <ColumnDefinition/>
                            </Grid.ColumnDefinitions>
                            
                            <Label Grid.Column="0" Content="Image here" 
                                   VerticalAlignment="Center" Padding="0,0,5,0"/>
                            
                            <AccessText Grid.Column="1" VerticalAlignment="Center">
                                <AccessText.Text>
                                    <MultiBinding StringFormat="{}_{0} {1}">
                                        <Binding Source="{StaticResource Test}"/>
                                        <Binding RelativeSource=
                                            "{RelativeSource TemplatedParent}" 
                                            Path="Subject"/>
                                    </MultiBinding>
                                </AccessText.Text>
                            </AccessText>
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
