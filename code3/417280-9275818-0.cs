    <ItemsControl Grid.Row="1" ItemsSource="{Binding Collection}">   
      <ItemsControl.ItemTemplate>   
       <DataTemplate>   
        <Grid>   
         <telerikGridView:RadGridView   
             ItemsSource="{Binding ElementName=RecordingDataPager, Path=PagedSource}">   
             <telerikGridView:RadGridView.Columns>   
                 <telerikGridView:GridViewDataColumn Header="Schedule" DataMemberBinding="{Binding Path=Schedule.Name}"/>   
                 </telerikGridView:RadGridView.Columns>   
             </telerikGridView:RadGridView>   
         <telerik:RadDataPager x:Name="RecordingDataPager"   
                  Source="{Binding Recordings, Mode=TwoWay}"/>   
        </Grid>   
     </DataTemplate>   
