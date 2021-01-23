        <Style TargetType="{x:Type Expander}">
            <Setter Property="Foreground" Value="Red"/>
            
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type Expander}">
                        <StackPanel>
                            <Border BorderThickness="{TemplateBinding BorderThickness}" TextBlock.Foreground="{TemplateBinding Foreground}">
                                <ContentPresenter Content="{TemplateBinding Header}" />
                            </Border>
                            <Border Name="Content" BorderThickness="{TemplateBinding BorderThickness}" TextBlock.Foreground="Blue">
                                <ContentPresenter Content="{TemplateBinding Content}" />
                            </Border>
                        </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    <Grid>
        <!-- Work -->
        <Expander Header="MyHeader" Content="MyContent" />
        <!-- Not work -->
        <!--<Expander Header="MyHeader">
            <Expander.Content>
                <TextBlock Text="Content"/>
            </Expander.Content>
        </Expander>-->
    </Grid>
