    <xctk:BusyIndicator x:Name="aaa" IsBusy="{Binding IsRunning}" 
                                     BusyContent="{Binding}" >
        <xctk:BusyIndicator.BusyContentTemplate>
            <DataTemplate>
                <Grid cal:Bind.Model="{Binding}">
                    <TextBlock Name="Message"/>
                </Grid>
            </DataTemplate>
        </xctk:BusyIndicator.BusyContentTemplate>
    </xctk:BusyIndicator>
