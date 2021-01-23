        public class ExtendedComboBox : ComboBox
        {
            public static readonly DependencyProperty PromptProperty =
                DependencyProperty.Register("Prompt", typeof(string), typeof(ExtendedComboBox), new PropertyMetadata(string.Empty));
            public string Prompt
            {
                get { return (string)GetValue(PromptTextProperty); }
                set { SetValue(PromptTextProperty, value); }
            }
        }
    We can cheat a bit and place a `TextBlock` with the prompt inside our control, and hide it when there's an item selected. For this we rewrite `ControlTemplate` of the control with a new one containing the `TextBlock`. I modified template from [there](http://stackoverflow.com/a/5728508/577167):
        <Style x:Key="PromptTextBlock" TargetType="{x:Type TextBlock}" >
            <Setter Property="Visibility" Value="Hidden" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding SelectedItem, RelativeSource={RelativeSource TemplatedParent}}" Value="{x:Null}">
                    <Setter Property="Visibility" Value="Visible" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
        <Style x:Key="PromptedComboBox" TargetType="{x:Type local:ExtendedComboBox}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:ExtendedComboBox}">
                        <Grid>
                            <ToggleButton x:Name="DropDownToggle"
                                          HorizontalAlignment="Stretch" VerticalAlignment="Stretch"  
                                          Margin="-1" HorizontalContentAlignment="Right"
                                          IsChecked="{Binding IsDropDownOpen, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}">
                                <Path x:Name="BtnArrow" Height="4" Width="8" 
                                      Stretch="Uniform" Margin="0,0,4,0"  Fill="Black"
                                      Data="F1 M 300,-190L 310,-190L 305,-183L 301,-190 Z " />
                            </ToggleButton>
                            <ContentPresenter x:Name="ContentPresenter" Margin="6,2,25,2"
                                              Content="{TemplateBinding SelectionBoxItem}"
                                              ContentTemplate="{TemplateBinding SelectionBoxItemTemplate}"
                                              ContentTemplateSelector="{TemplateBinding ItemTemplateSelector}">
                            </ContentPresenter>
                            <TextBox x:Name="PART_EditableTextBox"
                                     Style="{x:Null}"
                                     Focusable="False"
                                     Background="{TemplateBinding Background}"
                                     HorizontalAlignment="Left" 
                                     VerticalAlignment="Center" 
                                     Margin="3,3,23,3"
                                     Visibility="Hidden"
                                     IsReadOnly="{TemplateBinding IsReadOnly}"/>
                                <Popup x:Name="PART_Popup" IsOpen="{TemplateBinding IsDropDownOpen}">
                                    <Border x:Name="PopupBorder" 
                                            HorizontalAlignment="Stretch" Height="Auto" 
                                            MinWidth="{TemplateBinding ActualWidth}"
                                            MaxHeight="{TemplateBinding MaxDropDownHeight}"
                                            BorderThickness="{TemplateBinding BorderThickness}" 
                                            BorderBrush="Black" Background="White" CornerRadius="3">
                                        <ScrollViewer x:Name="ScrollViewer" BorderThickness="0" Padding="1">
                                            <ItemsPresenter/>
                                        </ScrollViewer>
                                    </Border>
                                </Popup>
                            <TextBlock Margin="4,3,20,3" Text="{Binding PromptText, RelativeSource={RelativeSource TemplatedParent}}" Style="{StaticResource PromptTextBlock}"/>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
             </Setter>
         </Style>
