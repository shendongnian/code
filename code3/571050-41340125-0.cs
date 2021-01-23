           // We have a class name 'Message' in ControllerLibrary Namespace
            
             namespace ControllerLibrary
                {
                  public class Message
                    {
                       public string MessageID { get; set; }
                        public string MessageName { get; set; }
                     }
                }
            
        // Add name space at page heading
                   xmlns:local1="using:ControllerLibrary"
            
          //At Gridview 
            
            <GridView IsItemClickEnabled="True" Name="UserMessageList">
             <GridView.ItemTemplate>
               <DataTemplate x:DataType="local1:Message">                                          <StackPanel Orientation="Horizontal">
             <Button Content="{x:Bind MessageName}" HorizontalAlignment="Left" Margin="2 0 10 0" Click="btnUserMessage_Click">
            </Button>
            </StackPanel>
            </DataTemplate>
             </GridView.ItemTemplate>
            </GridView>
        
      //At code Behind
        private void btnAddPage_Click(object sender, RoutedEventArgs e)
          {
              //Get selecte message
              var selectedMessage = (sender as Button).DataContext as Message;
          }
