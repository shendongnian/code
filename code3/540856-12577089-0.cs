    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        // Put these here instead of where they are now
        serviceClient.GetSectionsListCompleted += new EventHandler<GetSectionsListCompletedEventArgs>(serviceClient_GetSectionsListCompleted);
        serviceClient.GetSectionDetailCompleted += new EventHandler<GetSectionDetailCompletedEventArgs>(serviceClient_GetSectionDetailCompleted);
        serviceClient.GetDeptIDNameCompleted += new EventHandler<GetDeptIDNameCompletedEventArgs>(serviceClient_GetDeptIDNameCompleted);
        serviceClient.GetDeptIDNameAsync();
    }
