    <telerik:RadComboBox.ItemsSource>
        <CompositeCollection>
          <CollectionContainer
            Collection="{Binding ListOfNumbers}" />
          
          <telerik:RadComboBoxItem Name="Default" Content="All Builds" Value=""></telerik:RadComboBoxItem >
        </CompositeCollection>
      </telerik:RadComboBox.ItemsSource>
