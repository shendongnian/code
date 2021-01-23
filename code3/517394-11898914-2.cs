        <ContentControl x:Name="myContentControl" Content="{Binding}">
            <ContentControl.ContentTemplate>
                <DataTemplate>
                    <Grid>
                        <ComboBox x:Name="myComboBox" ItemsSource="{Binding}"/>
                        <TextBlock x:Name="myTextBlock"
                                   Text="Your choice.."
                                   IsHitTestVisible="False"
                                   Visibility="Hidden"/>
                    </Grid>
                    <DataTemplate.Triggers>
                        <Trigger SourceName="myComboBox" Property="SelectedItem" Value="{x:Null}">
                            <Setter TargetName="myTextBlock" Property="Visibility" Value="Visible"/>
                        </Trigger>
                    </DataTemplate.Triggers>
                </DataTemplate>
            </ContentControl.ContentTemplate>
        </ContentControl>
