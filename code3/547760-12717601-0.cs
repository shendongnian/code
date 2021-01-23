     <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ComboBoxItem">
                <StackPanel Orientation="Horizontal">
                    <ContentPresenter />
                    <TextBlock Name="HeaderHost" 
                               Text="{Binding Path=local:AttHeader.Header,
                                      RelativeSource={RelativeSource Mode=FindAncestor
                                      ,AncestorType=ComboBoxItem}}" />
                </StackPanel>
            </ControlTemplate>
        </Setter.Value>
     </Setter>
