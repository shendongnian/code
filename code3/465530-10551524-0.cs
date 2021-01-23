    <ListView ItemsSource="{Binding Items}">
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding Column1}" Header="Column 1" />
                <GridViewColumn DisplayMemberBinding="{Binding Column2}" Header="Column 2" />
                <GridViewColumn DisplayMemberBinding="{Binding Column3}" Header="Column 3" />
        </ListView.View>
    </ListView>
