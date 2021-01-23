     <Canvas>
        <TextBox Text="{Binding SelectedResult.Fname, UpdateSourceTrigger=PropertyChanged}" />
        <TextBox Text="{Binding SelectedResult.Lname, UpdateSourceTrigger=PropertyChanged}" />
        <Button Canvas.Left="90" Canvas.Top="65" Content="Remove" Click="button2_Click" Height="23" Name="button2" Width="75" />
        <Button Canvas.Left="10" Canvas.Top="65" Content="Save" Height="23" Name="button1" Width="75"  />
        <ListView Name="listviewStudents" Canvas.Top="100" ItemsSource="{Binding StudentModel.std}" SelectedItem="{Binding SelectedResult}" >
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="fname" DisplayMemberBinding="{Binding Path=Fname}"></GridViewColumn>
                    <GridViewColumn Header="lname" DisplayMemberBinding="{Binding Path=Lname}"></GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </Canvas>
