    <Button Command="{Binding RelativeSource={RelativeSource ItemsControl}, Path=DataContext.ToggleLedCommand}"
            CommandParameter="{Binding }">
        <Button.Template>
            <ControlTemplate TargetType="{x:Type Button}">
                <Ellipse Name="ellipse" Fill="Green"/>
                <ControlTemplate.Triggers>
                    <DataTemplate.Triggers>
                        <DataTrigger Binding="{Binding Path=State}" Value="Off">
                            <Setter TargetName="ellipse" Property="Fill" Value="Red"/>
                        </DataTrigger>
                    </DataTemplate.Triggers>
                </ControlTemplate.Triggers>
            </ControlTemplate>
       </Button.Template>
    </Button>
