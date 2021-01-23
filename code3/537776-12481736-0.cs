    Private Sub Command1_Click()
       Dim oPic As StdPicture
       Dim oWord As Object
       Dim oCommandBar As Object
       Dim oButton As Object
       
     ' Load the picture (.bmp file) to use for the button image.
       Set oPic = LoadPicture("C:\MyTestPic.bmp")
       
     ' Start Microsoft Word for Automation and create a new
     ' toolbar and button to test the PasteFace method.
       Set oWord = CreateObject("Word.Application")
       oWord.Visible = True
       
       Set oCommandBar = oWord.CommandBars.Add("Test Bar")
       oCommandBar.Visible = True
       
       Set oButton = oCommandBar.Controls.Add(1)
       With oButton
          .Caption = "Test Button"
          .Style = 1
          
        ' Here we create a mask based on the image and put both
        ' the image and the mask on the clipboard. Any color areas with
        ' magenta will be transparent.
          CopyBitmapAsButtonFace oPic, &HFF00FF
          
        ' PasteFace will now add the image with transparency.
          .PasteFace
          
          .Visible = True
       End With
       
       MsgBox "You have a new button with a transparent picture.", _
             vbMsgBoxSetForeground
       
       Set oButton = Nothing
       
       If MsgBox("Do you want to delete the toolbar?", _
            vbYesNo Or vbQuestion) = vbYes Then
          oCommandBar.Delete
       End If
       
       Set oCommandBar = Nothing
       Set oWord = Nothing
    End Sub
    					
