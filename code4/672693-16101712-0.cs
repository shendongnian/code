    public YourMainWindow()
    {
        ...
    
        // your populated dictionary
        Resources["MotDansTweets"] = MotDansTweet;
    
        InitializeComponent();
    }
    <ListView ItemsSource="{DynamicResource MotDansTweets}">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Key"
                                DisplayMemberBinding="{Binding Key}" />
                <GridViewColumn Header="UserName"
                                DisplayMemberBinding="{Binding Value.UserName}" />
                <GridViewColumn Header="ProfileImageUrl"
                                DisplayMemberBinding="{Binding Value.ProfileImageUrl}" />
            </GridView>
        </ListView.View>
     </ListView>
