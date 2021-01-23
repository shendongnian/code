    <ContextMenu.ItemContainerStyle>
          <Style TargetType="{x:Type MenuItem}">    
              <Setter Property="Command" Value="{Binding StartCommand}" />
              <Setter Property="CommandParameter" Value="{Binding RelativeSource={RelativeSource Self}, Path=Header}" />
              <Setter Property="ContextMenu"> 
                 <Setter.Value>
                    <ContextMenu StaysOpen="True">
                        <MenuItem Header="Set As Default"/>
                    </ContextMenu>
                 </Setter.Value>
              </Setter>
              <EventSetter Event="PreviewMouseRightButtonUp" Handler="MenuItem_Click"/>
          </Style>
    </ContextMenu.ItemContainerStyle>
