    <Window.Resources>
    <Style x:Key="Right90" TargetType="{x:Type TabItem}">           
            <Setter Property="HeaderTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <ContentPresenter Content="{TemplateBinding Content}" TextOptions.TextFormattingMode="Display">
                            <ContentPresenter.LayoutTransform>
                                <RotateTransform Angle="90" />
                            </ContentPresenter.LayoutTransform>
                        </ContentPresenter>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="Left90" TargetType="{x:Type TabItem}">          
            <Setter Property="HeaderTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <ContentPresenter Content="{TemplateBinding Content}" TextOptions.TextFormattingMode="Display">
                            <ContentPresenter.LayoutTransform>
                                <RotateTransform Angle="-90" />
                            </ContentPresenter.LayoutTransform>
                        </ContentPresenter>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
