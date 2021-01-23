    public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register("IsValid", typeof (bool), typeof (VegForm));
    public bool IsValid
    {
        get { return (bool) GetValue(IsValidProperty); }
        set { SetValue(IsValidProperty, value); }
    }
    <TabItem>
        <TabItem.Header>
            <Image>
                <Image.Style>
                    <Style TargetType="Image">
                        <!-- Replace "..." with valid "tick" image source -->
                        <Setter Property="Source" Value="..."/>
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding IsValid, ElementName=VegForm}" Value="False">
                                <!-- Replace "..." with valid "cross" image source -->
                                <Setter Property="Source" Value="..."/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Image.Style>
            </Image>
        </TabItem.Header>
        <VegForm x:Name="VegForm"/>
    </TabItem>
