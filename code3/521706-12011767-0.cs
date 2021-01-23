    private override void OnToolClick(ToolClickEventArgs e){
        if (e.Tool.Key == "SaveTool"){
             if (tbxJob == "")
                 MessageBox.Show("Error: No job was entered");
                 //Stop the save event from happening here
             else
                 base.OnToolClick(e);
        }
    }
