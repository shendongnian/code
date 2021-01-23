            <Style TargetType="DataGridCell">
                <Style.Triggers>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Path=Date.ValueChanged}" Value="True" />
                            <Condition Binding="{Binding Source={StaticResource BindProxy}, Path=Data.Columns.Date.NotifyChange}" Value="True" />
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation AutoReverse="True" From="#1F1F1F" To="#FFFF88" Duration="0:0:0.2" Storyboard.TargetProperty="Background.Color" FillBehavior="Stop" />
                                </Storyboard>
                            </BeginStoryboard>
                        </MultiDataTrigger.EnterActions>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
