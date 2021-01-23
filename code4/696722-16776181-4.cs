    <TabControl SelectionChanged="TabControl_SelectionChanged">
      <TabControl.ContentTemplate>
        <DataTemplate>
            <ContentPresenter Content="{Binding sub}" Loaded="smb_Loaded">
            </ContentPresenter>
        </DataTemplate>
      </TabControl.ContentTemplate>
    </TabControl>
