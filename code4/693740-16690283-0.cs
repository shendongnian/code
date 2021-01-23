    <scrollviewer ...>
      <grid> <!--New grid just to align the two panels-->
         <stackpanel x:Name="enableMe" IsEnabled="False" ...>
            ....
         </stackpanel>
         <border x:name="hideMe" Background="Transparent" Click="EnableStackPanel" ZIndex="1"/>
     </grid>
    </stackpanel>
    public void EnableStackPanel(...)
    {
      enableMe.IsEnabled=true;
      hideMe.Visibilty = Visibility.Collapsed;
    }
