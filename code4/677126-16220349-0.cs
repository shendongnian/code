    <ComboBox  ...>
        <ComboBox.ItemsSource>
            <MultiBinding Converter="{StaticResource ImageConverter}" Mode="OneWay">
                <MultiBinding.Bindings>
                    <Binding Path="TaskTitles" />
                    <Binding Path="FallbackTitles" />
                    <!--Binding Path="" /-->
                </MultiBinding.Bindings>
            </MultiBinding>
        </ComboBox.ItemsSource>
    </ComboBox>
