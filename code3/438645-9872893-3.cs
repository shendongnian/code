    <TabItem Header="Resource Allocation">
	<local:ItemsSelectionLists x:Name="ProjectResourceMap" LeftHeader="Whole Team" RightHeader="Current Project Team"/>
    </TabItem>
    <TabItem Header="Tasks for the Project">
	<local:ItemsSelectionLists x:Name="ProjectTaskMap" Margin="0" d:LayoutOverrides="Width" LeftHeader="All Tasks" RightHeader="Current Project Tasks"/>
    </TabItem>
    ViewModel<Resource> ProjectResource = new ViewModel<Resource>();
    ProjectResource.BindingMember = "ResourceName";
    this.ProjectResourceMap.DataSource = ProjectResource;
    ProjectResource.LeftCollection = timeTracker.Resources;
    
    ViewModel<Task> ProjectTasks = new ViewModel<Task>();
    ProjectTasks.BindingMember = "TaskName";
    this.ProjectTaskMap.DataSource = ProjectTasks;
    ProjectTasks.LeftCollection = timeTracker.Tasks;
