    <TabItem Name="MyTab" Header="This should be enabled when result is 2">
      <TabItem.IsEnabled>
         <MultiBinding Converter={StaticResource MyAddConverter}>
             <Binding Path=ValueA UpdateSourceTrigger=PropertyChanged />
             <Binding Path=ValueB UpdateSourceTrigger=PropertyChanged />
         </MultiBinding>
      </TabItem.IsEnabled>
        <!--Some other stuff-->
    </TabItem>
