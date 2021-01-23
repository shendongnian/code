    <ListView x:Name="lstGridWOResourceHogging" SelectionMode="Extended" ItemsSource="{Binding ObservableCollecitonInViewModel, IsAsync="True"
                  VirtualizingPanel.IsVirtualizing="False">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Column1Name" DisplayMemberBinding="{Binding Column1}"/>
                    <GridViewColumn Header="Column2Name" DisplayMemberBinding="{Binding Column2}"/>
                </GridView>
            </ListView.View>
        </ListView>
