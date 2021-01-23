                    <DataTemplate>
                        <DataTemplate.Resources>
                            <DataTemplate x:Key="Condition1"></DataTemplate>
                            <DataTemplate x:Key="Condition2"></DataTemplate>
                        </DataTemplate.Resources>                    
                    </DataTemplate>
                        <ContentPresenter x:Name="ContentField"
                                          Content="{Binding}"
                                          ContentTemplate="{StaticResource ResourceKey=Condition1}" /> 
                        <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding Path=IsMarried}" Value="True">
                                <Setter TargetName="ContentField" Property="ContentTemplate" Value="{StaticResource ResourceKey=Condition2}" />
                            </DataTrigger>
                        </DataTemplate.Triggers>   
