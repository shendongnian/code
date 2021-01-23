                    <DataTemplate>
                        <DataTemplate.Resources>
                            <DataTemplate x:Key="Condition1">
                               <TextBox></TextBox> // Do you binding
                            </DataTemplate>
                            <DataTemplate x:Key="Condition2">
                               <CheckBox></CheckBox> // Do you binding
                            </DataTemplate>
                        </DataTemplate.Resources>                    
                    </DataTemplate>
                        <ContentPresenter x:Name="ContentField"
                                          Content="{Binding}"
                                          ContentTemplate="{StaticResource ResourceKey=Condition1}" /> 
                        <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding Path=ValueType}" Value="1">
                                <Setter TargetName="ContentField" Property="ContentTemplate" Value="{StaticResource ResourceKey=Condition2}" />
                            </DataTrigger>
                        </DataTemplate.Triggers>   
