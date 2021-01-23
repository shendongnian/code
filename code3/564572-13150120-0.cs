    <ListView Name="LoggingListView" ItemsSource="{Binding LogEntries}">
        <ListView.View>
            <GridView>
               <GridViewColumn Header="Date" DisplayMemberBinding="{Binding Path=Date}"></GridViewColumn>
               <GridViewColumn Header="Time" DisplayMemberBinding="{Binding Path=Time}"></GridViewColumn>
               <GridViewColumn Header="Event" DisplayMemberBinding="{Binding Path=Event}"></GridViewColumn>
             </GridView>
        </ListView.View>
    </ListView>
