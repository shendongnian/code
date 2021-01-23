    <Style>
        <Style.Triggers>
            <DataTrigger Binding="{Binding IsRefreshing}"
                         Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard x:Name="rotating">
                        <Storyboard>
                            <DoubleAnimation... />
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                    <StopStoryboard BeginStoryboardName="rotating" />
                </DataTrigger.ExitActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
