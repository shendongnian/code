            // Attach window  menu
            UiNode wnd3 = UiFactory.Instance.NewUiNode().FromSelector("<wnd app='sap business one.exe' cls='&#35;32768' idx='1' />");            
            // Click 'Business Pa...' menu
            UiNode uiClickBusinessPamenu_3 = wnd3.FindFirst(UiFindScope.UI_FIND_DESCENDANTS, "<ctrl name='Business Partners' role='popup menu' /><ctrl automationid='2561' />");
            uiClickBusinessPamenu_3.Click(88, 9, UiClickType.UI_CLICK_SINGLE, UiMouseButton.UI_BTN_LEFT, UiInputMethod.UI_HARDWARE_EVENTS);            
            // Attach window 'SAP Business' 
            UiNode wnd4 = UiFactory.Instance.NewUiNode().FromSelector("<wnd app='sap business one.exe' cls='TMFrameClass' title='SAP Business One 9.0 - OEC Computers' />");            
            // Click 'Add' button
            UiNode uiClickAddbutton_4 = wnd4.FindFirst(UiFindScope.UI_FIND_DESCENDANTS, "<wnd cls='ToolbarWindow32' title='View' /><ctrl name='View' role='tool bar' /><ctrl name='Add' role='push button' />");
            uiClickAddbutton_4.Click(13, 24, UiClickType.UI_CLICK_SINGLE, UiMouseButton.UI_BTN_LEFT, UiInputMethod.UI_HARDWARE_EVENTS);
 
           
