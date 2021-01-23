Hmm, any chance to put the highlighting functionality in a DataTemplate? I implemented a highlighting for the selection state of an entity. And it works as expected.
&lt;DataTemplate.Triggers&gt;
  &lt;DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ListBoxItem}}"
                  Value="true"&gt;
  &lt;!-- Expand --&gt;
  &lt;DataTrigger.EnterActions&gt;
    &lt;BeginStoryboard&gt;
      &lt;Storyboard Storyboard.TargetName="CommandPanel"&gt;
        &lt;DoubleAnimation Duration="0:0:0.200" Storyboard.TargetProperty="Opacity" To="1" /&gt;
        &lt;DoubleAnimation Duration="0:0:0.150" Storyboard.TargetProperty="Height"
                            To="{StaticResource TargetHeightCommandPanel}" /&gt;
      &lt;/Storyboard&gt;
    &lt;/BeginStoryboard&gt;
  &lt;/DataTrigger.EnterActions&gt;
  &lt;!-- Collapse --&gt;
  &lt;DataTrigger.ExitActions&gt;
      &lt;BeginStoryboard&gt;
        &lt;Storyboard Storyboard.TargetName="CommandPanel"&gt;
          &lt;DoubleAnimation Duration="0:0:0.100" Storyboard.TargetProperty="Opacity" To="0" /&gt;
          &lt;DoubleAnimation Duration="0:0:0.150" Storyboard.TargetProperty="Height" To="0" /&gt;
        &lt;/Storyboard&gt;
      &lt;/BeginStoryboard&gt;
    &lt;/DataTrigger.ExitActions&gt;
  &lt;/DataTrigger&gt;
&lt;/DataTemplate.Triggers&gt;
