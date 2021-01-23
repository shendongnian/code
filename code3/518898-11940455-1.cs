    Public Sub checklistDropMenuChange(sender As Object, e As System.EventArgs) Handles checklistDropMenu.SelectedIndexChanged
    
        If (checklistDropMenu.SelectedValue = -1) Then
            taskDropMenu.Items.Clear()
            taskDropMenu.Enabled = False
        Else
            taskDropMenu.Enabled = True
            taskDropMenu.Items.Clear()
            taskList.SelectParameters("lngChecklist").DefaultValue = checklistDropMenu.SelectedValue
            taskDropMenu.DataBind()
        End If
        
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "KeepAddChecklistPopup", "showPopup('addChecklisTaskopup', 'add new Task');", True)
    End Sub
