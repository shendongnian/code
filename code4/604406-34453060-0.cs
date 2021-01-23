    <Grid>
        <ToggleButton x:Name="TogglePopupButton" Content="My Popup Toggle Button" Width="100" >
            <ToggleButton.Style>
                <Style TargetType="{x:Type ToggleButton}">
                    <Setter Property="IsHitTestVisible" Value="True"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=Popup, Path=IsOpen}" Value="True">
                            <Setter Property="IsHitTestVisible" Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ToggleButton.Style>
        </ToggleButton>
        <Popup StaysOpen="false" IsOpen="{Binding IsChecked, ElementName=TogglePopupButton, Mode=TwoWay}"
                   PlacementTarget="{Binding ElementName=TogglePopupButton}" PopupAnimation="Slide" 
               x:Name="Popup">
            <Border Width="100" Height="200" Background="White" BorderThickness="1" BorderBrush="Black">
                <TextBlock>This is a test</TextBlock>
            </Border>
        </Popup>
    </Grid>
