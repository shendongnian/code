    <DataTemplate x:Key="ManufacturerAView" TargetType="{x:Type local:WizardPageViewModelBase}">
        <TextBlock Text="I'm Manufacturer A" />
    </DataTemplate>
    
    <DataTemplate x:Key="ManufacturerBView" TargetType="{x:Type local:WizardPageViewModelBase}">
        <TextBlock Text="I'm Manufacturer B" />
    </DataTemplate>
    <ContentControl Content="{Binding }">
        <ContentControl.Style>
            <Style TargetType="{x:Type ContentControl}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Manufacturer}" Value="A">
                        <Setter Property="ContentTemplate" Value="{StaticResource ManufacturerAView}" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Manufacturer}" Value="B">
                        <Setter Property="ContentTemplate" Value="{StaticResource ManufacturerBView}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
