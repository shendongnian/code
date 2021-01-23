    Literal top = new Literal();
    // ...
    UpdatePanel UpdatePanel2 = new UpdatePanel();
    // ...
    top.Text = @"<div id='ChatBox' class='ChatBoxShown'>
                                                 <div class='ChatBoxHeader'>
                                                     <img id='ChatBoxStatusBtn' src='Images/status-online.png' />
                                                     <span id='ChatBoxUserLabel'>" + UserNames[0] + @"</span>
                                                     <img id='closeBtn' src='Images/close.png' />
                                                     <img id='toggleTab' src='Images/up-arrow.png' />
                                                 </div>";
    
    top.ID = "ChatBoxesLiteralTop";
    top.Mode = LiteralMode.PassThrough;
    // ...
    UpdatePanel2.ID = "UpdatePanel2";
    UpdatePanel2.UpdateMode = UpdatePanelUpdateMode.Conditional;
    UpdatePanel2.ChildrenAsTriggers = false;
    UpdatePanel2.ContentTemplateContainer.Controls.Add(top2);
    // ...
    Panel3.ContentTemplateContainer.Controls.Add(top);
    Panel3.ContentTemplateContainer.Controls.Add(UpdatePanel2);               
    Panel3.ContentTemplateContainer.Controls.Add(mid);
