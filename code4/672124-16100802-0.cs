      <Style TargetType="DataGridColumnHeader">
                        <Setter Property="Background">
                            <Setter.Value>
                                <MultiBinding Converter="{StaticResource ExcelColumnColorConverter}">
                                    <Binding RelativeSource="{RelativeSource AncestorType=DataGrid}"></Binding>
                                    <Binding RelativeSource="{RelativeSource self}" Path="Column"></Binding>
                                </MultiBinding>
                            </Setter.Value>
                        </Setter>
                    </Style>
