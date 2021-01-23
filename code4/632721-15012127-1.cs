    <telerik:GridViewComboBoxColumn Name="contactsGridViewComboBox"  Header="Contact"
            ItemsSource="{Binding ContactListObservable, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}}">
    <telerik:GridViewComboBoxColumn.CellTemplate>
        <DataTemplate>
            <TextBlock>
                <TextBlock.Text>
                    <MultiBinding  Converter="{StaticResource combinedFullNameAndPhoneExtensionConverter}">
                            <Binding Path="FullName"/>
                            <Binding Path="PhoneExtension"/>
                    </MultiBinding>
                </TextBlock.Text>
            </TextBlock>
        </DataTemplate>
    </telerik:GridViewComboBoxColumn.CellTemplate>
    <telerik:GridViewComboBoxColumn.CellEditTemplate>
        <DataTemplate x:Name="ContactsCellEditTemplate">
            <Grid FocusManager.FocusedElement="{Binding ElementName=ContactsTemplateComboBox}">
                <telerik:RadComboBox x:Name="ContactsTemplateComboBox" IsSynchronizedWithCurrentItem="False" IsEditable="False" ItemsSource="{Binding ContactListObservable, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}}"  IsDropDownOpen="True" TextSearchMode="Contains" IsFilteringEnabled="True" OpenDropDownOnFocus="True">
                    <telerik:RadComboBox.SelectedItem>
                        <MultiBinding Converter="{StaticResource combinedFullNameAndPhoneExtensionConverter}">
                            <Binding Path="FullName" UpdateSourceTrigger="PropertyChanged"/>
                            <Binding Path="PhoneExtension" UpdateSourceTrigger="PropertyChanged"/>
                        </MultiBinding>
                    </telerik:RadComboBox.SelectedItem>
                    <telerik:RadComboBox.ItemTemplate>
                        <DataTemplate>
                            <TextBlock DataContext="{Binding}">
                                <TextBlock.Text>                                                        
                                    <MultiBinding  Converter="{StaticResource combinedLastNameFirstNameAndPhoneExtensionConverter}">                             
                                        <Binding Path="LastName"/>                                                                                                                                                             <Binding Path="FirstName" />
                                        <Binding Path="PhoneExtension"/>
                                    </MultiBinding>
                                </TextBlock.Text>
                            </TextBlock>
                        </DataTemplate>
                    </telerik:RadComboBox.ItemTemplate>
                </telerik:RadComboBox>
            </Grid>
        </DataTemplate>
    </telerik:GridViewComboBoxColumn.CellEditTemplate>
