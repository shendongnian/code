      <ComboBox >
                <ComboBox.Style>
                    <Style TargetType="ComboBox">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding AnotherCollection.Count}" Value="0">
                                <Setter Property="Visibility" Value="Collapsed"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ComboBox.Style>
            </ComboBox>
