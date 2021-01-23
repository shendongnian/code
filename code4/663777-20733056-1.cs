    CommandBars cmdBrs  = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars);
    Microsoft.VisualStudio.CommandBars.CommandBar codeWindowCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["Code Window"];
    CommandBarPopup myNewPopUpControl = codeWindowCommandBar.Controls.Add(MsoControlType.msoControlPopup) as CommandBarPopup;
    myNewPopUpControl.Caption = "MyMenu";
    myNewPopUpControl.Visible = true;
