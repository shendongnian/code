    <Slider Margin="0,0,0,0" Height="100">
        <Slider.IsEnabled>
            <MultiBinding Converter="{StaticResource betweenTimeConverter}">
                <Binding Path="EarlyTime" />
                <Binding Path="LateTime" />
            </MultiBinding>
        </Slider.IsEnabled>
    </Slider>
